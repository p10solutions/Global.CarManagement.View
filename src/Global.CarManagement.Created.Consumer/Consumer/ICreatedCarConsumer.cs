
namespace Global.CarManagement.Created.Consumer.Consumer
{
    public interface ICreatedCarConsumer
    {
        Task Listen(CancellationToken cancellationToken);
    }
}
