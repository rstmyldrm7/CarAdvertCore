using CarAdvertCore.Application.Features.Tasks.Service.Abstract;
using CarAdvertCore.Domain.Entities;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static Confluent.Kafka.ConfigPropertyNames;

namespace CarAdvertCore.Application.Features.Tasks.Service.Concrete
{
    public class ApacheService : IApacheService
    {
        private IProducer<Null, string> _producer;
        public ApacheService()
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }
        public async Task MapToVisitEvent(Adverts advert, string ipAdress)
        {
            try
            {
                var visitRequest = new Visit()
                {
                    ID = Guid.NewGuid(),
                    advertId = advert.id,
                    iPAdress = ipAdress,
                    visitDate = DateTime.Now
                };
                await ProcessVisit(visitRequest);
            }
            catch
            { }
        }
        private async Task ProcessVisit(Visit visitRequest)
        {
            await _producer.ProduceAsync(topic: "demo", new Message<Null, string>()
            {
                Value = visitRequest.ToString()
            }, CancellationToken.None);
        }
    }
}
