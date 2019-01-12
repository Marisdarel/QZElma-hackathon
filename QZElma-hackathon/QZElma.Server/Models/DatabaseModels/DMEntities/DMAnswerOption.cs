using QZElma.Server.Models.Database.DBEntities;
using QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces;
using System;
using System.Linq.Expressions;


namespace QZElma.Server.Models.DatabaseModels.DMEntities
{
    /// <summary>
    /// Варианта ответа
    /// </summary>
    public class DMAnswerOption :
        IDMAnswerOption
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текст варианта ответа
        /// </summary>
        public string Text { get; set; }


        /// <summary>
        /// Выражение для преобразования сущностей БД в DM сущности
        /// </summary>
        /// <returns></returns>
        public static Expression<Func<AnswerOption, DMAnswerOption>> SelectExpression =
            en => new DMAnswerOption
            {
                Id = en.Id,
                Text = en.Text
            };
    }
}
