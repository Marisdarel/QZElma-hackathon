using LinqKit;
using QZElma.Server.Models.Database.DBEntities.Interfaces;
using QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces;
using System;
using System.Linq.Expressions;


namespace QZElma.Server.Models.Filters.DMFilters
{
    public class DMSelectionPredicateFactory<TDM, TDB>
        where TDM : class, IDMEntity
        where TDB : class, IDBEntity
    {
        /// <summary>
        /// Возвращает предикат-условие при котором сущность будет выдаваться в Get запросах.
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<TDB, bool>> Build()
        {
            var predicate = PredicateBuilder.New<TDB>(en => true);

            return predicate;
        }
    }
}
