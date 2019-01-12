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
        /// Текущий вопрос
        /// </summary>
        public int CurrentQuestion { get; set; }

        /// <summary>
        /// Вопросы
        /// </summary>
        public ICollection<MultipleChoiceQuestion> Questions { get; set; }
    }
}
