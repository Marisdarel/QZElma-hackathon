using System;
using System.Collections.Generic;

namespace QZElma.Server.Models.Database.DBEntities.Interfaces
{
    /// <summary>
    /// Вопрос с несколькими вариантами ответа
    /// </summary>
    public interface IMultipleChoiceQuestion :
        IDBIdEntity
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Варианты ответа
        /// </summary>
        ICollection<AnswerOption> Options { get; set; }

        /// <summary>
        /// Правильный вариант ответа
        /// </summary>
        Guid RightAnswerId { get; set; }
    }
}
