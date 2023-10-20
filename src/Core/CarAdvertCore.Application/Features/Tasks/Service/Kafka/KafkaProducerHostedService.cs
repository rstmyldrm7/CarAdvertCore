using CarAdvertCore.Domain.Entities;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Service.Kafka
{
    public class KafkaProducerHostedService : IHostedService
    {
        private IProducer<Null, string> _producer;
        public KafkaProducerHostedService()
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _producer.ProduceAsync(topic: "demo", new Message<Null, string>()
            {
                Value = "denemeConsumerRüstem"
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _producer?.Dispose();
            return Task.CompletedTask;
        }
    }
}
