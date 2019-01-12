using QZElma.Server.Models.Database.DBEntities.Interfaces;
using System;


namespace QZElma.Server.Models.Database.DBEntities
{
    /// <summary>
    /// Варианта ответа
    /// </summary>
    public class AnswerOption :
        IAnswerOption
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; }
    }
}
