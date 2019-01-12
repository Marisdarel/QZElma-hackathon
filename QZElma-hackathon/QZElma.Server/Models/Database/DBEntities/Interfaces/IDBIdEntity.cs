using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QZElma.Server.Models.Database.DBEntities.Interfaces
{
    /// <summary>
    /// Интерфейс сущностей БД с идентификаторами
    /// </summary>
    public interface IDBIdEntity :
        IDBEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        Guid Id { get; set; }
    }
}
