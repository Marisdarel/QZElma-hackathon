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
    /// Пользователь
    /// </summary>
    public class DMUser :
        BaseDMEntity<DMUser, User>,
        IDMUser
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор в чате
        /// </summary>
        public long ChatId { get; set; }


        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<User, DMUser>> GetSelectExpression()
        {
            return SelectExpression;
        }

        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<User, DMUser>> SelectExpression =
            en => new DMUser
            {
                Id = en.Id,
                Name = en.Name,
                ChatId = en.ChatId
            };

        /// <summary>
        /// Дополнительные изменения в БД для создания сущности
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">создаваемая в БД сущность</param>
        public void AdditionalCreate(ApplicationDBContext db, User entity)
        {
        }

        /// <summary>
        /// Дополнительные изменения в БД до обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        public void BeforeUpdate(ApplicationDBContext db, User entity)
        {
        }

        /// <summary>
        /// Дополнительные изменения в БД после обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        public void AfterUpdate(ApplicationDBContext db, User entity)
        {
        }

        /// <summary>
        /// Возвращает лямбда выражения для включения полей вложенных данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Expression<Func<User, object>>> GetIncludeExpressions()
        {
            return new List<Expression<Func<User, object>>>();
        }
    }
}
