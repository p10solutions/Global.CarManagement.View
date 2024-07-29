using Global.CarManagement.Created.Consumer.Consumer;

namespace Global.CarManagement.Created.Consumer
{
    public class Worker : BackgroundService
    {
        readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                var consumer =
                    scope.ServiceProvider.GetRequiredService<ICreatedCarConsumer>();

                await consumer.Listen(stoppingToken);
            }
        }
    }
}
