using QZElma.Server.Models.Database.EventModels.Events.Interfaces;
using System.Collections.Generic;


namespace QZElma.Server.Management.EventPublishers.Interfaces
{
    public interface IEventPublisher
    {
        /// <summary>
        /// Опубликовать событие
        /// </summary>
        /// <param name="someEvent">Событие</param>
        /// <returns></returns>
        void Publish(IEvent someEvent);

        /// <summary>
        /// Опубликовать несколько событий
        /// </summary>
        /// <param name="someEvents">События</param>
        /// <returns></returns>
        void Publish(ICollection<IEvent> someEvents);
    }
}
