using QZElma.Server.Models.Database.DBEntities.Interfaces;
using System;
using System.Collections.Generic;


namespace QZElma.Server.Models.Database.DBEntities
{
    /// <summary>
    /// Комната проведения викторины
    /// </summary>
    public class Room : IRoom
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
        public Quiz Quiz { get; set; }

        /// <summary>
        /// Пользователи
        /// </summary>
        public IEnumerable<User> Users { get; set; }
    }
}
