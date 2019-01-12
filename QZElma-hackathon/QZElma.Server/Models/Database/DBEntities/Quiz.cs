using QZElma.Server.Models.Database.DBEntities.Interfaces;
using System;
using System.Collections.Generic;

namespace QZElma.Server.Models.Database.DBEntities
{
    /// <summary>
    /// Викторина
    /// </summary>
    public class Quiz : IQuiz
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Вопросы
        /// </summary>
        public IEnumerable<MultipleChoiceQuestion> Questions { get; set; }
    }
}
