using QZElma.Server.Models.Database.DBEntities.Interfaces;
using System;


namespace QZElma.Server.Models.Database.DBEntities
{
    /// <summary>
    /// Ответ пользователя
    /// </summary>
    public class UserAnswer :
        IUserAnswer
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Идентификатор комнаты
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Идентификатор варианта ответа
        /// </summary>
        public Guid AnswerOptionId { get; set; }
    }
}
