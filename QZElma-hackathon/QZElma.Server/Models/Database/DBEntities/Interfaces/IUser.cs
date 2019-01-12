using System;

namespace QZElma.Server.Models.Database.DBEntities.Interfaces
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public interface IUser :
        IDBIdEntity
    {
        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Идентификатор в чате
        /// </summary>
        Guid ChatId { get; set; }
    }
}
