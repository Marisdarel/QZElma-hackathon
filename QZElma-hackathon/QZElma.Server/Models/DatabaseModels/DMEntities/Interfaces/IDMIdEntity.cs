using System;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Интерфейс сущностей БД с идентификаторами
    /// </summary>
    public interface IDMIdEntity :
        IDMEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        Guid Id { get; set; }
    }
}
