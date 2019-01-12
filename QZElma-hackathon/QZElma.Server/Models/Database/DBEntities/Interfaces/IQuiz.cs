using System.Collections.Generic;


namespace QZElma.Server.Models.Database.DBEntities.Interfaces
{
    /// <summary>
    /// Викторина
    /// </summary>
    public interface IQuiz :
        IDBIdEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Вопросы
        /// </summary>
        ICollection<MultipleChoiceQuestion> Questions { get; set; }
    }
}
