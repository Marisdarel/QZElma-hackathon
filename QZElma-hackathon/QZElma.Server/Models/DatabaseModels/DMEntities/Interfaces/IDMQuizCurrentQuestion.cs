using QZElma.Server.Models.Database.DBEntities;
using System;
using System.Collections.Generic;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Викторина...
    /// </summary>
    public interface IDMQuizCurrentQuestion :
        IDMIdEntity,
        IDMSelectable<DMQuizCurrentQuestion, Quiz>,
        IDMUpdatable<Quiz>
    {
        /// <summary>
        /// Текущий вопрос
        /// </summary>
        int CurrentQuestion { get; set; }
    }
}
