using System;


namespace QZElma.Server.Models.Database.DBEntities.Interfaces
{
    /// <summary>
    /// Ответ пользователя
    /// </summary>
    public interface IUserAnswer :
        IDBIdEntity
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
