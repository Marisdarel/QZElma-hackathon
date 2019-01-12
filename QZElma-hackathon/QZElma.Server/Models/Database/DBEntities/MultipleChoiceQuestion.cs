using QZElma.Server.Models.Database.DBEntities.Interfaces;
using System;
using System.Collections.Generic;


namespace QZElma.Server.Models.Database.DBEntities
{
    /// <summary>
    /// Вопрос с несколькими вариантами ответа
    /// </summary>
    public class MultipleChoiceQuestion :
        IMultipleChoiceQuestion
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Варианты ответа
        /// </summary>
        public ICollection<AnswerOption> Options { get; set; }

        /// <summary>
        /// Правильный вариант ответа
        /// </summary>
        public Guid RightAnswerId { get; set; }
    }
}
