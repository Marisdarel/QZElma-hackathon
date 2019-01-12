using QZElma.Server.Models.Database.DBEntities;
using QZElma.Server.Models.DatabaseModels.DMEntities.Base;
using QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace QZElma.Server.Models.DatabaseModels.DMEntities
{
    /// <summary>
    /// Вопрос с идентификаторами вариантов ответа
    /// </summary>
    public class DMMultipleChoiceQuestionOptionIds :
        BaseDMEntity<DMMultipleChoiceQuestionOptionIds, MultipleChoiceQuestion>,
        IDMMultipleChoiceQuestionOptionIds
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификаторы вариантов ответа
        /// </summary>
        public IEnumerable<Guid> OptionIds { get; set; }


        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<MultipleChoiceQuestion, DMMultipleChoiceQuestionOptionIds>> GetSelectExpression()
        {
            return SelectExpression;
        }

        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<MultipleChoiceQuestion, DMMultipleChoiceQuestionOptionIds>> SelectExpression =
            en => new DMMultipleChoiceQuestionOptionIds
            {
                Id = en.Id,
                OptionIds = en.Options.Select(op => op.Id)
            };
    }
}
