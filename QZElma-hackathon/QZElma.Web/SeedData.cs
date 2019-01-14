using QZElma.Server.Management.DBRepositories.Interfaces;
using QZElma.Server.Models.Database.DBEntities;
using QZElma.Server.Models.DatabaseModels.DMEntities;
using System;
using System.Collections.Generic;

namespace QZElma.Web
{
    public class SeedData
    {
        protected readonly IDBRepository<Room> _roomRepository;
        protected readonly IDBRepository<Quiz> _quizRepository;
        protected readonly IDBRepository<MultipleChoiceQuestion> _questionRepository;

        [HelperSelfService]
        public SeedData(
            IDBRepository<Room> roomRepository,
            IDBRepository<Quiz> quizRepository,
            IDBRepository<MultipleChoiceQuestion> questionRepository)
        {
            _roomRepository = roomRepository;
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
        }

        public void Init()
        {
            _questionRepository.Create(new DMMultipleChoiceQuestion() {
                Id = new Guid("2b2c8ad8-f1f7-425c-a9fb-3ef0f54f247b"),
                Text = "Самый частый вопрос, который слышит этот человек – «Ты где?». Кто же это?",
                Options = new List<DMAnswerOption>() {
                    new DMAnswerOption()
                    {
                        Id = new Guid("c4730179-a900-4192-bf94-a82b3f78cb36"),
			            Text = "Наталья Самойлова"
                    },
		            new DMAnswerOption()
                    {
			            Id = new Guid("08593bc9-7287-4e1e-b076-15fda9310755"),
			            Text = "Анатолий Варанкин"
		            },
		            new DMAnswerOption()
                    {
			            Id = new Guid("27b22573-931f-4cf5-b132-55624a799437"),
			            Text = "Юлия Батальцева"
		            },
		            new DMAnswerOption()
                    {
			            Id = new Guid("f11200cb-4be7-4de3-8c83-a9c38da546f0"),
			            Text = "Антон Кононов"
		            }
                },
                RightAnswerId = new Guid("08593bc9-7287-4e1e-b076-15fda9310755")
            });

            _questionRepository.Create(new DMMultipleChoiceQuestion()
            {
                Id = new Guid("b93af616-26e0-472b-b8de-aff4db85287a"),
                Text = "Кто по праву носит звание «Самого большого человека в Элме?»",
                Options = new List<DMAnswerOption>() {
                    new DMAnswerOption()
                    {
                        Id = new Guid("aae92b66-3b07-4e00-a72b-ede2b2667a50"),
                        Text = "Валентина Казакова"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("6b76e7b4-6405-4fc7-9867-3ac0b0ef6366"),
                        Text = "Ксения Пивкина"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("6b79c99b-d12e-45b3-ac35-420f2ab9521d"),
                        Text = "Андрей Чепакин"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("f29b3334-c0b4-4f65-bd14-05228b5fa4d1"),
                        Text = "Миша Саратов"
                    }
                },
                RightAnswerId = new Guid("6b79c99b-d12e-45b3-ac35-420f2ab9521d")
            });

            _questionRepository.Create(new DMMultipleChoiceQuestion()
            {
                Id = new Guid("1b54fb79-cb31-4879-81bb-f8ba41cdb346"),
                Text = "На одном из хакатонов разрабатывался проект голосового помощника в Элме. Какое имя носил этот голосовой помощник?",
                Options = new List<DMAnswerOption>() {
                    new DMAnswerOption()
                    {
                        Id = new Guid("eb0803e6-6e5b-4185-a80b-bd6c3616caaa"),
                        Text = "Алиса"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("c8e4e440-870b-45a5-9232-341f934f15fb"),
                        Text = "Блокчейн"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("6e54333a-3f57-4137-a3d2-495410e1ad90"),
                        Text = "Бертольд"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("131a8d75-3ffb-432d-8857-bdaa85dc13f6"),
                        Text = "Толян"
                    }
                },
                RightAnswerId = new Guid("131a8d75-3ffb-432d-8857-bdaa85dc13f6")
            });

            _questionRepository.Create(new DMMultipleChoiceQuestion()
            {
                Id = new Guid("e5a4afc4-69b8-49f0-8e2a-6809c53184e3"),
                Text = "В одном из отделов нашей компании доля людей с одинаковым именем равна 75%. Что это за отдел?",
                Options = new List<DMAnswerOption>() {
                    new DMAnswerOption()
                    {
                        Id = new Guid("391e2bbe-7873-44b1-9092-88487c5c7d0a"),
                        Text = "HR"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("6c9a6b14-6304-40b3-b720-00e14324611c"),
                        Text = "Внедрение"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("9aa6f092-80d6-4472-be11-ef8178ae3415"),
                        Text = "Юлевайз Projects"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("89efa391-5570-432a-a90e-45a945925ecf"),
                        Text = "Отдел документирования"
                    }
                },
                RightAnswerId = new Guid("391e2bbe-7873-44b1-9092-88487c5c7d0a")
            });

            _questionRepository.Create(new DMMultipleChoiceQuestion()
            {
                Id = new Guid("e5854b94-645b-4a91-9b02-3505c0374bb1"),
                Text = "Один из модулей, входящий с специальную сборку для «Сбербанк Казахстан» носит кодовое имя «… замещение». Вставьте пропущенное слово.",
                Options = new List<DMAnswerOption>() {
                    new DMAnswerOption()
                    {
                        Id = new Guid("e9c674b2-ca41-4ec3-ae47-c782b2d7d413"),
                        Text = "Жидкое"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("99536837-aa5d-491d-b62b-e7c5e57b5587"),
                        Text = "Густое"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("f441bf63-b5cf-43c1-a1c7-b1838e3192fd"),
                        Text = "Мягкое"
                    },
                    new DMAnswerOption()
                    {
                        Id = new Guid("5f3a6ff1-1a6f-45ff-9536-425d02b5bd4b"),
                        Text = "Теплое"
                    }
                },
                RightAnswerId = new Guid("f441bf63-b5cf-43c1-a1c7-b1838e3192fd")
            });
        }
    }
}
