using QZElma.Server.Models.Database.EventModels.Events.Interfaces;
using QZElma.Server.Models.DatabaseModels.DMEntities;
using System.Collections.Generic;


namespace QZElma.Server.Models.Database.EventModels.Events
{
    /// <summary>
    /// Событие отправка нового вопроса
    /// </summary>
    public class EventSendNextQuestion :
        IEvent
    {
        public IEnumerable<long> UserChatIds { get; set; }

        public DMMultipleChoiceQuestion Question { get; set; }
    }
}
