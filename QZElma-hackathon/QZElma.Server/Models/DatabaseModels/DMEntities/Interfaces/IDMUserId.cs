using QZElma.Server.Models.Database.DBEntities;
using System;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    public interface IDMUserId :
        IDMIdEntity,
        IDMSelectable<DMUserId, User>
    {
        /// <summary>
        /// Идентификатор в чате
        /// </summary>
        long ChatId { get; set; }
    }
}
