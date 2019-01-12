using QZElma.Server.Models.Database.DBEntities.Interfaces;
using QZElma.Server.Models.DatabaseModels.Interfaces;
using QZElma.Server.Models.Filters.DMFilters;
using System;
using System.Linq.Expressions;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Base
{
    public abstract class BaseDMEntity<TDM, TDB> :
        IDMSelectable<TDM, TDB>
        where TDM : class, IDMEntity
        where TDB : class, IDBIdEntity
    {
        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности.
        /// </summary>
        /// <returns></returns>
        public abstract Expression<Func<TDB, TDM>> GetSelectExpression();

        /// <summary>
        /// Возвращает предикат-условие при котором сущность будет выдаваться в Get запросах.
        /// </summary>
        /// <returns></returns>
        public virtual Expression<Func<TDB, bool>> GetSelectionPredicate()
        {
            return DMSelectionPredicateFactory<TDM, TDB>.Build();
        }
    }
}
