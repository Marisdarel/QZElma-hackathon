using QZElma.Server.Models.Database.EventModels.Events.Interfaces;
using System;


namespace QZElma.Server.Models.Database.EventModels.Events
{
    /// <summary>
    /// Событие викторина началась
    /// </summary>
    public class EventQuizStarted :
        IEvent
    {
        /// <summary>
        /// Идентификатор комнаты
        /// </summary>
        public Guid RoomId { get; set; }
    }
}
