using DotNetCore.CAP;


namespace QZElma.Server.Management.EventSubscribers.Interfaces
{
    /// <summary>
    /// Интерфейс для подписчиков на сообщения
    /// </summary>
    public interface IEventSubscriber : ICapSubscribe
    {
    }
}
