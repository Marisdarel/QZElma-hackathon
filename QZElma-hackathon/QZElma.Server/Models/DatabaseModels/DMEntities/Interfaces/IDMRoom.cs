using QZElma.Server.Models.Database.DBEntities;
using System.Collections.Generic;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Комната проведения викторины
    /// </summary>
    public interface IDMRoom :
        IDMIdEntity,
        IDMSelectable<DMRoom, Room>,
        IDMCreatable<Room>,
        IDMUpdatable<Room>
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Викторина
        /// </summary>
        DMQuiz Quiz { get; set; }

        /// <summary>
        /// Пользователи
        /// </summary>
        IEnumerable<DMUser> Users { get; set; }
    }
}
