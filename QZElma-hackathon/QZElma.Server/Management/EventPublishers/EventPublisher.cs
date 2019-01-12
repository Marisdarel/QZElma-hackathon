using DotNetCore.CAP;
using QZElma.Server.Management.EventPublishers.Interfaces;
using QZElma.Server.Models.Attributes;
using QZElma.Server.Models.Database.EventModels.Events.Interfaces;
using System.Collections.Generic;


namespace QZElma.Server.Management.EventPublishers
{
    /// <summary>
    /// Интерфейс для публикаторов сообщений
    /// </summary>
    [HelperService]
    class EventPublisher : IEventPublisher
    {
        private readonly ICapPublisher _capPublisher;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="capPublisher"></param>
        public EventPublisher(ICapPublisher capPublisher)
        {
            _capPublisher = capPublisher;
        }

        /// <summary>
        /// Опубликовать событие
        /// </summary>
        /// <param name="someEvent">Событие</param>
        /// <returns></returns>
        public void Publish(IEvent someEvent)
        {
            var name = someEvent.GetType().ToString();

            //TODO async
            _capPublisher.Publish(name, someEvent);
        }

        /// <summary>
        /// Опубликовать несколько событий
        /// </summary>
        /// <param name="someEvents">События</param>
        /// <returns></returns>
        public void Publish(IEnumerable<IEvent> someEvents)
        {
            foreach (var someEvent in someEvents)
            {
                Publish(someEvent);
            }
        }
    }
}
