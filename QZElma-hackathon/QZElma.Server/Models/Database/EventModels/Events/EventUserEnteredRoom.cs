using QZElma.Server.Models.Database.EventModels.Events.Interfaces;
using System;


namespace QZElma.Server.Models.Database.EventModels.Events
{
    /// <summary>
    /// Событие пользователь вошёл в комнату
    /// </summary>
    public class EventUserEnteredRoom :
        IEvent
    {
        /// <summary>
        /// Идентификатор пользователя в чате
        /// </summary>
        public long UserChatId { get; set; }

        /// <summary>
        /// Имя пользователя в чате
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Идентификатор комнаты
        /// </summary>
        public Guid RoomId { get; set; }
    }
}
