﻿using QZElma.Server.Models.Database.EventModels.Events.Interfaces;
using System;


namespace QZElma.Server.Models.Database.EventModels.Events
{
    /// <summary>
    /// Событие пользователь ответил на вопрос
    /// </summary>
    public class EventUserAnsweredQuestion :
        IEvent
    {
        /// <summary>
        /// Идентификатор пользователя в чате
        /// </summary>
        public Guid UserChatId { get; set; }

        /// <summary>
        /// Идентификатор ответа
        /// </summary>
        public Guid AnswerId { get; set; }
    }
}