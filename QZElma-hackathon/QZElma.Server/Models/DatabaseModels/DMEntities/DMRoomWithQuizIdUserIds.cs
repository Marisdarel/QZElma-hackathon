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
    public class DMRoomWithQuizIdUserIds :
        BaseDMEntity<DMRoomWithQuizIdUserIds, Room>,
        IDMRoomWithQuizIdUserIds
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
        /// Идентификатор викторины
        /// </summary>
        public Guid QuizId { get; set; }

        /// <summary>
        /// Идентификаторы пользователей
        /// </summary>
        public IEnumerable<Guid> UserIds { get; set; }


        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<Room, DMRoomWithQuizIdUserIds>> GetSelectExpression()
        {
            return SelectExpression;
        }

        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<Room, DMRoomWithQuizIdUserIds>> SelectExpression =
            en => new DMRoomWithQuizIdUserIds
            {
                Id = en.Id,
                Name = en.Name,
                QuizId = en.Quiz == null ? Guid.Empty : en.Quiz.Id,
                UserIds = en.Quiz == null ? new List<Guid>() : en.Users.Select(us => us.Id)
            };

        /// <summary>
        /// Дополнительные изменения в БД для создания сущности
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">создаваемая в БД сущность</param>
        public void AdditionalCreate(ApplicationDBContext db, Room entity)
        {
            if (QuizId != Guid.Empty)
            {
                entity.Quiz = db.Set<Quiz>().Find(QuizId);
            }

            if (UserIds != null)
            {
                entity.Users = new List<User>();
                foreach (var userId in UserIds)
                {
                    entity.Users.Add(db.Set<User>().Find(userId));
                }
            }
        }
    }
}
