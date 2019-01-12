using QZElma.Server.Models.Database.DBEntities.Interfaces;
using System;
using System.Linq.Expressions;


namespace QZElma.Server.Models.DatabaseModels.Interfaces
{
    /// <summary>
    /// Интерфейс позволяющий получать сущность
    /// </summary>
    /// <typeparam name="TDM"></typeparam>
    /// <typeparam name="TDB"></typeparam>
    public interface IDMSelectable<TDM, TDB> :
        IDMEntity
        where TDM : IDMEntity
        where TDB : IDBIdEntity
    {
        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности.
        /// </summary>
        /// <returns></returns>
        Expression<Func<TDB, TDM>> GetSelectExpression();

        /// <summary>
        /// Возвращает предикат-условие при котором сущность будет выдаваться в Get запросах.
        /// </summary>
        /// <returns></returns>
        Expression<Func<TDB, bool>> GetSelectionPredicate();
    }
}
