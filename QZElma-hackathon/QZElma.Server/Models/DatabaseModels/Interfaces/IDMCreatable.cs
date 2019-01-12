using QZElma.Server.Models.Database.DBContexts;
using QZElma.Server.Models.Database.DBEntities.Interfaces;


namespace QZElma.Server.Models.DatabaseModels.Interfaces
{
    /// <summary>
    /// Интерфейс позволяющий создавать сущность
    /// </summary>
    /// <typeparam name="TDB"></typeparam>
    public interface IDMCreatable<TDB> :
        IDMEntity
        where TDB : class, IDBEntity
    {
        /// <summary>
        /// Дополнительные изменения в БД для создания сущности.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">создаваемая в БД сущность</param>
        void AdditionalCreate(ApplicationDBContext db, TDB entity);
    }
}
