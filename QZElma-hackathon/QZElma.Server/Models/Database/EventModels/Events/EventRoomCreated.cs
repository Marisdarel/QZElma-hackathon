using QZElma.Server.Models.Database.EventModels.Events.Interfaces;
using System;


namespace QZElma.Server.Models.Database.EventModels.Events
{
    /// <summary>
    /// Событие комната создана
    /// </summary>
    public class EventRoomCreated :
        IEvent
    {
        /// <summary>
        /// Название комнаты
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// Количество вопросов в комнате
        /// </summary>
        public int QuestionCount { get; set; }

        /// <summary>
        /// Идентификатор пользователя в чате, создавшего комнату
        /// </summary>
        public long UserChatId { get; set; }

        /// <summary>
        /// Имя пользователя в чате, создавшего комнату
        /// </summary>
        public string UserName { get; set; }
    }
}
