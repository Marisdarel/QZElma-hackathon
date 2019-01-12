using QZElma.Server.Management.EventSubscribers.Interfaces;
using QZElma.Server.Models.Database.EventModels.Events;


namespace QZElma.Server.Management.Services.Interfaces
{
    /// <summary>
    /// Сервис управления комнатами
    /// </summary>
    public interface IRoomService :
        IEventSubscriber
    {
        /// <summary>
        /// Создаёт комнату
        /// </summary>
        void CreateRoom(EventRoomCreated @event);

        /// <summary>
        /// Добавляет пользователя в комнату
        /// </summary>
        void AddUserToRoom(EventUserEnteredRoom @event);

        /// <summary>
        /// Запускает викторину
        /// </summary>
        void StartQuiz(EventQuizStarted @event);

        /// <summary>
        /// Принимает ответ пользователя
        /// </summary>
        void ReceiveUserAnswer(EventUserAnsweredQuestion @event);
    }
}
