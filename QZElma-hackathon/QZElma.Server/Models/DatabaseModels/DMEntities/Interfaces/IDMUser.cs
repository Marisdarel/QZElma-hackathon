using QZElma.Server.Models.Database.DBEntities;
using System;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public interface IDMUser :
        IDMIdEntity,
        IDMSelectable<DMUser, User>,
        IDMCreatable<User>,
        IDMUpdatable<User>
    {
        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Идентификатор в чате
        /// </summary>
        long ChatId { get; set; }
    }
}
