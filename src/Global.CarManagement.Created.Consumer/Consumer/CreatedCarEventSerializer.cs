using Confluent.Kafka;
using System.Text.Json;
using System.Text;
using Global.CarManagement.View.Domain.Models.Events.Cars;

namespace Global.CarManagement.Created.Consumer.Consumer
{
    internal class CreatedCarEventSerializer : IDeserializer<CreatedCarEvent>
    {
        public CreatedCarEvent Deserialize(ReadOnlySpan<byte> data, bool isNull,SerializationContext context)
        {
            var json = Encoding.ASCII.GetString(data.ToArray());

            return JsonSerializer.Deserialize<CreatedCarEvent>(json);
        }
    }
}
