using CarAdvertCore.Application.Features.Tasks.Service.Abstract;
using CarAdvertCore.Domain.Entities;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Confluent.Kafka.ConfigPropertyNames;

namespace CarAdvertCore.Application.Features.Tasks.Service.Concrete
{
    public class ApacheService : IApacheService
    {
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
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                ClientId = "kafka-producer"
            };

            using (var producer = new ProducerBuilder<Null, Visit>(config).Build())
            {
                var topic = "Visit-topic";

                try
                {
                    var result = await producer.ProduceAsync(topic, new Message<Null, Visit> { Value = visitRequest });

                    if (result.Status == PersistenceStatus.Persisted)
                    {
                        Console.WriteLine($"Message successfully produced: {result.Offset}");
                    }
                }
                catch (ProduceException<Null, Visit> e)
                {

                    Console.WriteLine($"Kafka message production error: {e.Error.Reason}");
                }
            }
        }
    }
}
