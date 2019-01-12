using AutoMapper;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using QZElma.Server.Exceptions;
using QZElma.Server.Management.DBRepositories.Interfaces;
using QZElma.Server.Models.Attributes;
using QZElma.Server.Models.Database.DBContexts;
using QZElma.Server.Models.Database.DBEntities.Interfaces;
using QZElma.Server.Models.DatabaseModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace QZElma.Server.Management.DBRepositories
{
    [RepositoryService]
    public class DBRepository<TDB> : IDBRepository<TDB>
        where TDB : class, IDBIdEntity
    {
        protected ApplicationDBContext _db;


        public DBRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Начинает транзакцию
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction BeginTransaction()
        {
            return _db.Database.BeginTransaction();
        }

        /// <summary>
        /// Проверяет существование сущности
        /// </summary>
        /// <param name="id">id проверяемой сущности</param>
        /// <returns></returns>
        public bool Exists(Guid id)
        {
            var entity = _db.Find<TDB>(id);
            if (entity == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Создаёт сущность
        /// </summary>
        /// <param name="dmEntity"></param>
        /// <returns>Id добавленной сущности сохраняется в dmEntity.Id</returns>
        public virtual void Create<TDM>(TDM dmEntity)
            where TDM : IDMCreatable<TDB>
        {
            var entity = Mapper.Map<TDM, TDB>(dmEntity);

            // создаём сущность
            dmEntity.AdditionalCreate(_db, entity);

            _db.Add(entity);
            _db.SaveChanges();
        }

        /// <summary>
        /// Удаляет сущность
        /// </summary>
        /// <param name="id">id удаляемой сущности</param>
        /// <returns></returns>
        public void Delete(Guid id)
        {
            var entity = _db.Find<TDB>(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TDB), id);
            }

            _db.Set<TDB>().Remove(entity);
            _db.SaveChanges();
        }

        /// <summary>
        /// Обновляет сущность
        /// </summary>
        /// <param name="dmEntity">сущность с новыми данными</param>
        /// <returns></returns>
        public void Update<TDM>(TDM dmEntity)
            where TDM : IDMUpdatable<TDB>
        {
            IQueryable<TDB> query = _db.Set<TDB>();

            // включаем ссылочные данные
            var includeExpressions = dmEntity.GetIncludeExpressions();
            foreach (var expression in includeExpressions)
            {
                query = query.Include(expression);
            }

            // получаем предыдущие значения
            var entity = query
                .Where(en => en.Id == dmEntity.Id)
                .SingleOrDefault();

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TDB), dmEntity.Id);
            }

            // меняем нужные нам поля
            dmEntity.BeforeUpdate(_db, entity);
            Mapper.Map<TDM, TDB>(dmEntity, entity);
            dmEntity.AfterUpdate(_db, entity);

            _db.SaveChanges();
        }

        /// <summary>
        /// Возвращает сущность типа TDM по id
        /// </summary>
        /// <param name="id">id запрашиваемой сущности</param>
        /// <returns></returns>
        public TDM Get<TDM>(Guid id)
            where TDM : IDMSelectable<TDM, TDB>, new()
        {
            var dmEntity = new TDM();
            var entities = _db.Set<TDB>()
                .Where(en => en.Id == id)
                .Where(dmEntity.GetSelectionPredicate());

            return ToDatabaseModels<TDM>(entities)
                .FirstOrDefault();
        }

        /// <summary>
        /// Возвращает все сущности типа TDM
        /// </summary>
        /// <param name="from">Смещение от первого найденного результата</param>
        /// <param name="size">Количество выдаваемых результатов</param>
        /// <returns></returns>
        public ICollection<TDM> GetAll<TDM>(int from, int size)
            where TDM : IDMSelectable<TDM, TDB>, new()
        {
            var dmEntity = new TDM();
            var entities = _db.Set<TDB>()
                .Where(dmEntity.GetSelectionPredicate())
                .Skip(from)
                .Take(size);

            return ToDatabaseModels<TDM>(entities)
                .ToList();
        }

        /// <summary>
        /// Возвращает все сущности типа TDM, удовлетворяющие predicate
        /// </summary>
        /// <param name="predicate">условие для запрашиваемых сущностей</param>
        /// <param name="from">Смещение от первого найденного результата</param>
        /// <param name="size">Количество выдаваемых результатов</param>
        /// <returns></returns>
        public ICollection<TDM> GetList<TDM>(Func<TDM, bool> predicate, int from = 0, int size = -1)
            where TDM : IDMSelectable<TDM, TDB>, new()
        {
            var dmEntity = new TDM();
            var entities = _db.Set<TDB>()
                .Where(dmEntity.GetSelectionPredicate())
                .Skip(from);

            if (size != -1)
            {
                entities.Take(size);
            }

            return ToDatabaseModels<TDM>(entities)
                .Where(predicate)
                .ToList();
        }

        /// <summary>
        /// Преобразует TE сущности в TDM сущности
        /// </summary>
        /// <typeparam name="TDM"></typeparam>
        /// <param name="db"></param>
        /// <returns></returns>
        protected IQueryable<TDM> ToDatabaseModels<TDM>(IQueryable<TDB> db)
            where TDM : IDMSelectable<TDM, TDB>, new()
        {
            var dmEntity = new TDM();

            return db
                .AsExpandable()
                .Select(dmEntity.GetSelectExpression());
        }
    }
}
