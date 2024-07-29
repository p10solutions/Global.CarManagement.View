using AutoMapper;
using Confluent.Kafka;
using Global.CarManagement.View.Application.Features.Cars.Commands.CreateCar;
using Global.CarManagement.View.Domain.Models.Events.Cars;
using MediatR;


namespace Global.CarManagement.Created.Consumer.Consumer
{
    public class CreatedCarConsumer : ICreatedCarConsumer
    {
        readonly ConsumerConfig _config;
        readonly string _topic;
        readonly IMediator _mediator;
        readonly ILogger<CreatedCarConsumer> _logger;
        readonly IMapper _mapper;

        public CreatedCarConsumer(IConfiguration configuration, IMediator mediator, ILogger<CreatedCarConsumer> logger, IMapper mapper)
        {
            _config = new ConsumerConfig
            {
                BootstrapServers = configuration.GetSection("Kafka:Server").Value,
                GroupId = configuration.GetSection("Kafka:ConsumerGroupId").Value,
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            _topic = configuration.GetSection("Kafka:Car:CreateTopic").Value;
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Listen(CancellationToken cancellationToken)
        {
            using var consumer = new ConsumerBuilder<Null, CreatedCarEvent>(_config)
                .SetValueDeserializer(new CreatedCarEventSerializer())
                .Build();

            consumer.Subscribe(_topic);

            _logger.LogInformation("Listening to events...");
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var createdCarEvent = consumer.Consume(cancellationToken);

                    if (createdCarEvent is null)
                        continue;

                    _logger.LogInformation("A new Car was received");

                    var command = _mapper.Map<CreateCarCommand>(createdCarEvent.Value);

                    await _mediator.Send(command, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error ocurred when try get the event from kafka: {Message}", ex.Message);
                }
            }
        }
    }
}
