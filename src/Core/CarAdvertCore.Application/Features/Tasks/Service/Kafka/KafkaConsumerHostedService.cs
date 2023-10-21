using CarAdvertCore.Application.Contracts.Persistence;
using CarAdvertCore.Application.Features.Tasks.Service.Abstract;
using CarAdvertCore.Domain.Entities;
using Confluent.Kafka;
using Kafka.Public;
using Kafka.Public.Loggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Service.Kafka
{
    public class KafkaConsumerHostedService : IHostedService
    {
        private ClusterClient _cluster;
        private readonly IVisitRepository _visitRepository;
        private static string _topic;
        public KafkaConsumerHostedService(IVisitRepository visitRepository, IConfiguration configuration)
        {
            _cluster = new ClusterClient(new Configuration
            {
                Seeds = configuration["KafkaSettings:Server"]
            }, new ConsoleLogger());
            var config = new ProducerConfig()
            {
                BootstrapServers = configuration["KafkaSettings:Server"]
            };
            _visitRepository = visitRepository;
            _topic = configuration["KafkaSettings:Topic"];
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _cluster.ConsumeFromLatest(topic: _topic);
            _cluster.MessageReceived += async record =>
            {
                var readAsString = Encoding.UTF8.GetString(record.Value as byte[]);
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var visit = JsonSerializer.Deserialize<Visit>(readAsString, options);
                await _visitRepository.AddAsync(visit);
            };
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cluster?.Dispose();
            return Task.CompletedTask;
        }
    }
}
