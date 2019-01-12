using LinqKit;
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
    public class DMQuizWithQuestionIds :
        BaseDMEntity<DMQuizWithQuestionIds, Quiz>,
        IDMQuizWithQuestionIds
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Идентификаторы вопросов
        /// </summary>
        public IEnumerable<Guid> QuestionIds { get; set; }


        /// <summary>
        /// Возвращает выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<Quiz, DMQuizWithQuestionIds>> GetSelectExpression()
        {
            return SelectExpression;
        }

        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<Quiz, DMQuizWithQuestionIds>> SelectExpression =
            en => new DMQuizWithQuestionIds
            {
                Id = en.Id,
                Name = en.Name,
                QuestionIds = en.Questions == null ? new List<Guid>() : en.Questions.Select(qs => qs.Id)
            };

        /// <summary>
        /// Дополнительные изменения в БД для создания сущности
        /// </summary>
        /// <param name="db">контекст БД</param>
        /// <param name="entity">создаваемая в БД сущность</param>
        public void AdditionalCreate(ApplicationDBContext db, Quiz entity)
        {
            if (QuestionIds == null)
            {
                return;
            }

            entity.Questions = new List<MultipleChoiceQuestion>();
            foreach (var questionId in QuestionIds)
            {
                entity.Questions.Add(db.Set<MultipleChoiceQuestion>().Find(questionId));
            }
        }
    }
}
