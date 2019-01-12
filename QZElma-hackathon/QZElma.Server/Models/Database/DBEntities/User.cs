using QZElma.Server.Models.Database.DBEntities.Interfaces;
using System;


namespace QZElma.Server.Models.Database.DBEntities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : IUser
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
    }
}
