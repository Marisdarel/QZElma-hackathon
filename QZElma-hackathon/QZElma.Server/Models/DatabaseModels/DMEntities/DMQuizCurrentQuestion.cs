﻿using LinqKit;
using QZElma.Server.Models.Database.DBContexts;
using QZElma.Server.Models.Database.DBEntities;
using QZElma.Server.Models.DatabaseModels.DMEntities.Base;
using QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace QZElma.Server.Models.DatabaseModels.DMEntities
{
    /// <summary>
    /// Викторина с идентификаторами вопросов
    /// </summary>
    public class DMQuizCurrentQuestion :
        BaseDMEntity<DMQuizCurrentQuestion, Quiz>,
        IDMQuizCurrentQuestion
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public int CurrentQuestion { get; set; }


        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<Quiz, DMQuizCurrentQuestion>> GetSelectExpression()
        {
            return SelectExpression;
        }

        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<Quiz, DMQuizCurrentQuestion>> SelectExpression =
            en => new DMQuizCurrentQuestion
            {
                Id = en.Id,
                CurrentQuestion = en.CurrentQuestion
            };

        /// <summary>
        /// Дополнительные изменения в БД до обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        public void BeforeUpdate(ApplicationDBContext db, Quiz entity)
        {
        }

        /// <summary>
        /// Дополнительные изменения в БД после обновления данных сущности в БД.
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">обновляемая в БД сущность</param>
        public void AfterUpdate(ApplicationDBContext db, Quiz entity)
        {
        }

        /// <summary>
        /// Возвращает лямбда выражения для включения полей вложенных данных
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Expression<Func<Quiz, object>>> GetIncludeExpressions()
        {
            return new List<Expression<Func<Quiz, object>>>();
        }
    }
}
