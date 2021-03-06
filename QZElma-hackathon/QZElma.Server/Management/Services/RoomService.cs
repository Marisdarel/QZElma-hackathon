﻿using Microsoft.Extensions.Configuration;
using QZElma.Server.Management.DBRepositories.Interfaces;
using QZElma.Server.Management.EventPublishers.Interfaces;
using QZElma.Server.Management.Services.Interfaces;
using QZElma.Server.Models.Attributes;
using QZElma.Server.Models.Database.DBEntities;
using QZElma.Server.Models.Database.EventModels.Events;
using QZElma.Server.Models.DatabaseModels.DMEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


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
        private readonly IConfiguration configuration;
        protected readonly IDBRepository<Quiz> _quizRepository;
        protected readonly IDBRepository<MultipleChoiceQuestion> _questionRepository;
        protected readonly IDBRepository<User> _userRepository;
        protected readonly IDBRepository<UserAnswer> _userAnswerRepository;
        IEventPublisher _eventPublisher;

        static Timer timer;

        /// <summary>
        /// Конструктор
        /// </summary>
        public RoomService(
            IDBRepository<Room> roomRepository,
            IConfiguration configuration,
            IDBRepository<Quiz> quizRepository,
            IDBRepository<MultipleChoiceQuestion> questionRepository,
            IDBRepository<User> userRepository,
            IDBRepository<UserAnswer> userAnswerRepository,
            IEventPublisher eventPublisher)
        {
            _roomRepository = roomRepository;
            this.configuration = configuration;
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
            _userRepository = userRepository;
            _userAnswerRepository = userAnswerRepository;
            _eventPublisher = eventPublisher;
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

            //TODO проверка на принадлежность только одной комнате??

            var roomId = configuration.GetSection("DefaultRoomId").Value;

            var roomUserIds = _roomRepository.Get<DMRoomUserIds>(Guid.Parse(roomId));
            roomUserIds.UserIds.Add(userId);

            _roomRepository.Update(roomUserIds);
        }

        /// <summary>
        /// Запускает викторину
        /// </summary>
        [EventSubscribtion(typeof(EventQuizStarted))]
        public void StartQuiz(EventQuizStarted @event)
        {
            // устанавливаем метод обратного вызова
            var tm = new TimerCallback(SendNextQuestion);
            // создаем таймер
            timer = new Timer(tm, @event.RoomId, 0, 10000);
        }

        /// <summary>
        /// Принимает ответ пользователя
        /// </summary>
        [EventSubscribtion(typeof(EventUserAnsweredQuestion))]
        public void ReceiveUserAnswer(EventUserAnsweredQuestion @event)
        {
            var userId = GetOrCreateUserId(@event.UserChatId, @event.UserName);

            // проверка на существование ответа
            var userAnswer = _userAnswerRepository.GetList<DMUserAnswer>(x => x.AnswerOptionId == @event.AnswerOptionId);
            if (userAnswer.Count() != 0)
            {
                return;
            }

            // одна комната для пользователя
            var rooms = _roomRepository.GetList<DMRoomUserIds>(x => x.UserIds.Contains(userId));
            var room = rooms.FirstOrDefault();

            if (room == null)
                return;

            var questions = _questionRepository.GetList<DMMultipleChoiceQuestionOptionIds>(x => x.OptionIds.Contains(@event.AnswerOptionId));
            var question = questions.FirstOrDefault();

            if (question == null)
                return;

            _userAnswerRepository.Create(new DMUserAnswer() {
                Id = Guid.NewGuid(),
                UserId = userId,
                RoomId = room.Id,
                QuestionId = question.Id,
                AnswerOptionId = @event.AnswerOptionId
            });
        }

        private void SendNextQuestion(object obj)
        {
            var roomId = (Guid)obj;

            var room = _roomRepository.Get<DMRoom>(roomId);
            var quiz = _quizRepository.Get<DMQuizCurrentQuestion>(room.Quiz.Id);

            quiz.CurrentQuestion += 1;

            if (room.Quiz.Questions.Count() > room.Quiz.CurrentQuestion)
            {
                
                _quizRepository.Update(quiz);

                var count = 0;
                var questions = room.Quiz.Questions;
                foreach (var question in questions)
                {
                    if (count++ == room.Quiz.CurrentQuestion)
                    {
                        _eventPublisher.Publish(new EventSendNextQuestion()
                        {
                            UserChatIds = room.Users.Select(x => x.ChatId),
                            Question = question
                        });
                        return;
                    }
                }
            }
            else
            {

            }
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
