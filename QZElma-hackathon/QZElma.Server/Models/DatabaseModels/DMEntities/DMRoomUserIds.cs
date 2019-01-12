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
    /// Идентификаторы пользователей комнаты проведения викторины
    /// </summary>
    public class DMRoomUserIds :
        BaseDMEntity<DMRoomUserIds, Room>,
        IDMRoomUserIds
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификаторы пользователей
        /// </summary>
        public ICollection<Guid> UserIds { get; set; }


        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<Room, DMRoomUserIds>> GetSelectExpression()
        {
            return SelectExpression;
        }

        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<Room, DMRoomUserIds>> SelectExpression =
            en => new DMRoomUserIds
            {
                Id = en.Id,
                UserIds = en.Quiz == null ? new List<Guid>() : en.Users.Select(us => us.Id)
            };

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
            if (UserIds == null)
            {
                return;
            }

            var userIdsToBeAdded = UserIds;
            if (entity.Users != null)
            {
                var usersToBeDeleted = entity.Users
                    .Where(us => UserIds.All(usId => usId != us.Id)).ToList();

                foreach (var user in usersToBeDeleted)
                {
                    entity.Users.Remove(user);
                }

                userIdsToBeAdded = UserIds
                    .Where(usId => entity.Users.All(us => us.Id != usId)).ToList();
            }

            foreach (var userId in userIdsToBeAdded)
            {
                entity.Users.Add(db.Set<User>().Find(userId));
            }
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
