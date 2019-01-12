using QZElma.Server.Models.Database.DBEntities;
using System;


namespace QZElma.Server.Models.DatabaseModels.DMEntities.Interfaces
{
    /// <summary>
    /// Ответ пользователя
    /// </summary>
    public interface IDMUserAnswer :
        IDMIdEntity,
        IDMSelectable<DMUserAnswer, UserAnswer>,
        IDMCreatable<UserAnswer>,
        IDMUpdatable<UserAnswer>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор комнаты
        /// </summary>
        Guid RoomId { get; set; }

        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        Guid QuestionId { get; set; }

        /// <summary>
        /// Идентификатор варианта ответа
        /// </summary>
        Guid AnswerOptionId { get; set; }
    }
}
