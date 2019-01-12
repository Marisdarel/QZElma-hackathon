using QZElma.Server.Models.Database.DBEntities;
using System.Collections.Generic;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Викторина
    /// </summary>
    public interface IDMQuiz :
        IDMIdEntity,
        IDMSelectable<DMQuiz, Quiz>,
        IDMCreatable<Quiz>,
        IDMUpdatable<Quiz>
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Вопросы
        /// </summary>
        IEnumerable<DMMultipleChoiceQuestion> Questions { get; set; }

        /// <summary>
        /// Текущий вопрос
        /// </summary>
        int CurrentQuestion { get; set; }
    }
}
