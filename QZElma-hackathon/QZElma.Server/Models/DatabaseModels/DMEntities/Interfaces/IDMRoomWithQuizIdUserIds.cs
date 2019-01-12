using QZElma.Server.Models.Database.DBEntities;
using System;
using System.Collections.Generic;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Комната проведения викторины
    /// </summary>
    public interface IDMRoomWithQuizIdUserIds :
        IDMIdEntity,
        IDMSelectable<DMRoomWithQuizIdUserIds, Room>,
        IDMCreatable<Room>
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Идентификатор викторины
        /// </summary>
        Guid QuizId { get; set; }

        /// <summary>
        /// Идентификаторы пользователей
        /// </summary>
        IEnumerable<Guid> UserIds { get; set; }
    }
}
