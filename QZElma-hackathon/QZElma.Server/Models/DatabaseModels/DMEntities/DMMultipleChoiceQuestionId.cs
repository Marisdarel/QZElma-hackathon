using LinqKit;
using QZElma.Server.Models.Database.DBContexts;
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
    /// Идентификатор вопроса с несколькими вариантами ответа
    /// </summary>
    public class DMMultipleChoiceQuestionId :
        BaseDMEntity<DMMultipleChoiceQuestionId, MultipleChoiceQuestion>,
        IDMMultipleChoiceQuestionId
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<MultipleChoiceQuestion, DMMultipleChoiceQuestionId>> GetSelectExpression()
        {
            return SelectExpression;
        }

        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<MultipleChoiceQuestion, DMMultipleChoiceQuestionId>> SelectExpression =
            en => new DMMultipleChoiceQuestionId
            {
                Id = en.Id
            };
    }
}
