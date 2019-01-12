using QZElma.Server.Models.Database.DBEntities;
using System;
using System.Collections.Generic;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Идентификаторы пользователей комнаты проведения викторины
    /// </summary>
    public interface IDMRoomUserIds :
        IDMIdEntity,
        IDMSelectable<DMRoomUserIds, Room>,
        IDMUpdatable<Room>
    {
        /// <summary>
        /// Идентификаторы пользователей
        /// </summary>
        ICollection<Guid> UserIds { get; set; }
    }
}
