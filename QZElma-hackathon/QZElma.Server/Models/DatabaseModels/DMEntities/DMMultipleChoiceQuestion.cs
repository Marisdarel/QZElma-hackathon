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
    /// Вопрос с несколькими вариантами ответа
    /// </summary>
    public class DMMultipleChoiceQuestion :
        BaseDMEntity<DMMultipleChoiceQuestion, MultipleChoiceQuestion>,
        IDMMultipleChoiceQuestion
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Варианты ответа
        /// </summary>
        public IEnumerable<DMAnswerOption> Options { get; set; }

        /// <summary>
        /// Правильный вариант ответа
        /// </summary>
        public Guid RightAnswerId { get; set; }


        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<MultipleChoiceQuestion, DMMultipleChoiceQuestion>> GetSelectExpression()
        {
            return SelectExpression;
        }

        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<MultipleChoiceQuestion, DMMultipleChoiceQuestion>> SelectExpression =
            en => new DMMultipleChoiceQuestion
            {
                Id = en.Id,
                Text = en.Text,
                RightAnswerId = en.RightAnswerId,
                Options = en.Options.Select(op => DMAnswerOption.SelectExpression.Invoke(op))
            };

        /// <summary>
        /// Дополнительные изменения в БД для создания сущности
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">создаваемая в БД сущность</param>
        public void AdditionalCreate(ApplicationDBContext db, MultipleChoiceQuestion entity)
        {
        }

        /// <summary>
        /// Дополнительные изменения в БД до обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        public void BeforeUpdate(ApplicationDBContext db, MultipleChoiceQuestion entity)
        {
        }

        /// <summary>
        /// Дополнительные изменения в БД после обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        public void AfterUpdate(ApplicationDBContext db, MultipleChoiceQuestion entity)
        {
        }

        /// <summary>
        /// Возвращает лямбда выражения для включения полей вложенных данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Expression<Func<MultipleChoiceQuestion, object>>> GetIncludeExpressions()
        {
            return new List<Expression<Func<MultipleChoiceQuestion, object>>>();
        }
    }
}
