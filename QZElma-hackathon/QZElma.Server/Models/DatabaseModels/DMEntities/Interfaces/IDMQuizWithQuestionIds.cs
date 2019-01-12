using QZElma.Server.Models.Database.DBEntities;
using System;
using System.Collections.Generic;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Викторина с идентификаторами вопросов
    /// </summary>
    public interface IDMQuizWithQuestionIds :
        IDMIdEntity,
        IDMSelectable<DMQuizWithQuestionIds, Quiz>,
        IDMCreatable<Quiz>
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Идентификаторы вопросов
        /// </summary>
        IEnumerable<Guid> QuestionIds { get; set; }
    }
}
