using QZElma.Server.Models.Database.DBContexts;
using QZElma.Server.Models.Database.DBEntities;
using QZElma.Server.Models.DatabaseModels.DMEntities.Base;
using QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace QZElma.Server.Models.DatabaseModels.DMEntities
{
    /// <summary>
    /// Ответ пользователя
    /// </summary>
    public class DMUserAnswer :
        BaseDMEntity<DMUserAnswer, UserAnswer>,
        IDMUserAnswer
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор комнаты
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Идентификатор варианта ответа
        /// </summary>
        public Guid AnswerOptionId { get; set; }


        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<UserAnswer, DMUserAnswer>> GetSelectExpression()
        {
            return SelectExpression;
        }

        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<UserAnswer, DMUserAnswer>> SelectExpression =
            en => new DMUserAnswer
            {
                Id = en.Id,
                UserId = en.UserId,
                RoomId = en.RoomId,
                QuestionId = en.QuestionId,
                AnswerOptionId = en.AnswerOptionId
            };

        /// <summary>
        /// Дополнительные изменения в БД для создания сущности
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">создаваемая в БД сущность</param>
        public void AdditionalCreate(ApplicationDBContext db, UserAnswer entity)
        {
        }

        /// <summary>
        /// Дополнительные изменения в БД до обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        public void BeforeUpdate(ApplicationDBContext db, UserAnswer entity)
        {
        }

        /// <summary>
        /// Дополнительные изменения в БД после обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        public void AfterUpdate(ApplicationDBContext db, UserAnswer entity)
        {
        }

        /// <summary>
        /// Возвращает лямбда выражения для включения полей вложенных данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Expression<Func<UserAnswer, object>>> GetIncludeExpressions()
        {
            return new List<Expression<Func<UserAnswer, object>>>();
        }
    }
}
