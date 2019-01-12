using QZElma.Server.Models.Database.DBEntities;
using System;
using System.Collections.Generic;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Вопрос с несколькими вариантами ответа
    /// </summary>
    public interface IDMMultipleChoiceQuestion :
        IDMIdEntity,
        IDMSelectable<DMMultipleChoiceQuestion, MultipleChoiceQuestion>,
        IDMCreatable<MultipleChoiceQuestion>,
        IDMUpdatable<MultipleChoiceQuestion>
    {
        /// <summary>
        /// Текст вопроса
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Варианты ответа
        /// </summary>
        IEnumerable<DMAnswerOption> Options { get; set; }

        /// <summary>
        /// Правильный вариант ответа
        /// </summary>
        Guid RightAnswerId { get; set; }
    }
}
