using QZElma.Server.Management.DBRepositories.Interfaces;
using QZElma.Server.Management.Services.Interfaces;
using QZElma.Server.Models.Attributes;
using QZElma.Server.Models.Database.DBEntities;
using QZElma.Server.Models.Database.EventModels.Events;
using QZElma.Server.Models.DatabaseModels.DMEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QZElma.Server.Management.Services
{
    /// <summary>
    /// Сервис управления комнатами
    /// </summary>
    [SingletonService]
    public class RoomService :
        IRoomService
    {
        protected readonly IDBRepository<Room> _roomRepository;
        protected readonly IDBRepository<Quiz> _quizRepository;
        protected readonly IDBRepository<MultipleChoiceQuestion> _questionRepository;
        protected readonly IDBRepository<User> _userRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public RoomService(
            IDBRepository<Room> roomRepository,
            IDBRepository<Quiz> quizRepository,
            IDBRepository<MultipleChoiceQuestion> questionRepository,
            IDBRepository<User> userRepository)
        {
            _roomRepository = roomRepository;
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Создаёт комнату
        /// </summary>
        [EventSubscribtion(typeof(EventRoomCreated))]
        public void CreateRoom(EventRoomCreated @event)
        {
            var userId = GetOrCreateUserId(@event.UserChatId, @event.UserName);

            //TODO random
            var questionIds = _questionRepository.GetAll<DMMultipleChoiceQuestionId>(0, @event.QuestionCount).Select(x => x.Id);
            var quiz = new DMQuizWithQuestionIds() {
                Id = Guid.NewGuid(),
                Name = @event.RoomName,
                QuestionIds = questionIds
            };
            _quizRepository.Create(quiz);

            _roomRepository.Create(new DMRoomWithQuizIdUserIds()
            {
                Name = @event.RoomName,
                QuizId = quiz.Id,
                UserIds = new List<Guid>() {
                    userId
                }
            });
        }

        /// <summary>
        /// Добавляет пользователя в комнату
        /// </summary>
        [EventSubscribtion(typeof(EventUserEnteredRoom))]
        public void AddUserToRoom(EventUserEnteredRoom @event)
        {
            var userId = GetOrCreateUserId(@event.UserChatId, @event.UserName);

            var roomUserIds = _roomRepository.Get<DMRoomUserIds>(@event.RoomId);
            roomUserIds.UserIds.Add(userId);

            _roomRepository.Update(roomUserIds);
        }

        /// <summary>
        /// Запускает викторину
        /// </summary>
        [EventSubscribtion(typeof(EventQuizStarted))]
        public void StartQuiz(EventQuizStarted @event)
        {
        }

        /// <summary>
        /// Принимает ответ пользователя
        /// </summary>
        [EventSubscribtion(typeof(EventUserAnsweredQuestion))]
        public void ReceiveUserAnswer(EventUserAnsweredQuestion @event)
        {
        }

        private Guid GetOrCreateUserId(long userChatId, string userName)
        {
            // проверяем существование пользователя
            var users = _userRepository.GetList<DMUserId>(x => x.ChatId == userChatId);
            var user = users.FirstOrDefault();

            if (user == null)
            {
                user = new DMUserId()
                {
                    Id = Guid.NewGuid(),
                    ChatId = userChatId
                };

                // создаём нового пользователя
                _userRepository.Create(new DMUser()
                {
                    Id = user.Id,
                    Name = userName,
                    ChatId = user.ChatId
                });
            }

            return user.Id;
        }
    }
}
