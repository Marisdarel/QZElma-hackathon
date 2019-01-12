using System.Collections.Generic;


namespace QZElma.Server.Models.Database.DBEntities.Interfaces
{
    /// <summary>
    /// Комната проведения викторины
    /// </summary>
    public interface IRoom :
        IDBIdEntity
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Викторина
        /// </summary>
        Quiz Quiz { get; set; }

        /// <summary>
        /// Пользователи
        /// </summary>
        ICollection<User> Users { get; set; }
    }
}
