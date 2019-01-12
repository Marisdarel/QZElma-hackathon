using QZElma.Server.Models.Database.DBContexts;
using QZElma.Server.Models.Database.DBEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Интерфейс позволяющий обновлять сущность
    /// </summary>
    /// <typeparam name="TDB"></typeparam>
    public interface IDMUpdatable<TDB> :
        IDMIdEntity
        where TDB : class, IDBIdEntity
    {
        /// <summary>
        /// Возвращает лямбда выражения для включения полей вложенных данных.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Expression<Func<TDB, object>>> GetIncludeExpressions();

        /// <summary>
        /// Дополнительные изменения в БД до обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        void BeforeUpdate(ApplicationDBContext db, TDB entity);

        /// <summary>
        /// Дополнительные изменения в БД после обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        void AfterUpdate(ApplicationDBContext db, TDB entity);
    }
}
