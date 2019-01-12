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
    /// Комната проведения викторины
    /// </summary>
    public class DMRoom :
        BaseDMEntity<DMRoom, Room>,
        IDMRoom
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Викторина
        /// </summary>
        public DMQuiz Quiz { get; set; }

        /// <summary>
        /// Пользователи
        /// </summary>
        public IEnumerable<DMUser> Users { get; set; }


        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<Room, DMRoom>> GetSelectExpression()
        {
            return SelectExpression;
        }

        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<Room, DMRoom>> SelectExpression =
            en => new DMRoom
            {
                Id = en.Id,
                Name = en.Name,
                Quiz = DMQuiz.SelectExpression.Invoke(en.Quiz),
                Users = en.Users.Select(us => DMUser.SelectExpression.Invoke(us))
            };

        /// <summary>
        /// Дополнительные изменения в БД для создания сущности
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">создаваемая в БД сущность</param>
        public void AdditionalCreate(ApplicationDBContext db, Room entity)
        {
        }

        /// <summary>
        /// Дополнительные изменения в БД до обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        public void BeforeUpdate(ApplicationDBContext db, Room entity)
        {
        }

        /// <summary>
        /// Дополнительные изменения в БД после обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        public void AfterUpdate(ApplicationDBContext db, Room entity)
        {
        }

        /// <summary>
        /// Возвращает лямбда выражения для включения полей вложенных данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Expression<Func<Room, object>>> GetIncludeExpressions()
        {
            return new List<Expression<Func<Room, object>>>();
        }
    }
}
