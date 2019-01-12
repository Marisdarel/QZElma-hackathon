using QZElma.Server.Models.Database.DBEntities;
using System;
using System.Collections.Generic;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Вопрос с идентификаторами вариантов ответа
    /// </summary>
    public interface IDMMultipleChoiceQuestionOptionIds :
        IDMIdEntity,
        IDMSelectable<DMMultipleChoiceQuestionOptionIds, MultipleChoiceQuestion>
    {
        /// <summary>
        /// Идентификаторы вариантов ответа
        /// </summary>
        IEnumerable<Guid> OptionIds { get; set; }
    }
}
