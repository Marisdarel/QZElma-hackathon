using Microsoft.EntityFrameworkCore.Storage;
using QZElma.Server.Models.Database.DBEntities.Interfaces;
using QZElma.Server.Models.DatabaseModels.Interfaces;
using System;
using System.Collections.Generic;


namespace QZElma.Server.Management.DBRepositories.Interfaces
{
    public interface IDBRepository<TDB>
        where TDB : class, IDBIdEntity
    {
        /// <summary>
        /// Начинает транзакцию
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTransaction();

        /// <summary>
        /// Проверяет существование сущности
        /// </summary>
        /// <param name="id">id проверяемой сущности</param>
        /// <returns></returns>
        bool Exists(Guid id);

        /// <summary>
        /// Создаёт сущность
        /// </summary>
        /// <param name="dmEntity"></param>
        /// <returns>Id добавленной сущности сохраняется в dmEntity.Id</returns>
        void Create<TDM>(TDM dmEntity)
            where TDM : IDMCreatable<TDB>;

        /// <summary>
        /// Удаляет сущность
        /// </summary>
        /// <param name="id">id удаляемой сущности</param>
        /// <returns></returns>
        void Delete(Guid id);

        /// <summary>
        /// Обновляет сущность
        /// </summary>
        /// <param name="dmEntity">сущность с новыми данными</param>
        /// <returns></returns>
        void Update<TDM>(TDM dmEntity)
            where TDM : IDMUpdatable<TDB>;

        /// <summary>
        /// Возвращает сущность типа TDM по id
        /// </summary>
        /// <param name="id">id запрашиваемой сущности</param>
        /// <returns></returns>
        TDM Get<TDM>(Guid id)
            where TDM : IDMSelectable<TDM, TDB>, new();

        /// <summary>
        /// Возвращает все сущности типа TDM
        /// </summary>
        /// <param name="from">Смещение от первого найденного результата</param>
        /// <param name="size">Количество выдаваемых результатов</param>
        /// <returns></returns>
        ICollection<TDM> GetAll<TDM>(int from, int size)
            where TDM : IDMSelectable<TDM, TDB>, new();

        /// <summary>
        /// Возвращает все сущности типа TDM, удовлетворяющие predicate
        /// </summary>
        /// <param name="predicate">условие для запрашиваемых сущностей</param>
        /// <param name="from">Смещение от первого найденного результата</param>
        /// <param name="size">Количество выдаваемых результатов</param>
        /// <returns></returns>
        ICollection<TDM> GetList<TDM>(Func<TDM, bool> predicate, int from = 0, int size = -1)
            where TDM : IDMSelectable<TDM, TDB>, new();
    }
}
