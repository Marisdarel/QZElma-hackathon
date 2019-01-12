using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ChatBotService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QZElma.Server.Management.EventPublishers.Interfaces;
using QZElma.Server.Models.Database.EventModels.Events;
using QZElma.Server.Models.DatabaseModels.DMEntities;
using Telegram.Bot.Types;

namespace QZElma.Web.Controllers
{
    public class MessageController : ControllerBase
    {
        private readonly ChatBot chatBot;
        private readonly ILogger<MessageController> logger;
        private readonly IEventPublisher publisher;
        private readonly ChatBotListener listener;

        public MessageController(ChatBot chatBot, ILogger<MessageController> logger, IEventPublisher publisher)
        {
            this.chatBot = chatBot;
            this.logger = logger;
            this.publisher = publisher;
        }

        public IActionResult StartRoom()
        {
            var startEvent = new EventQuizStarted()
            {
                RoomId = Guid.Empty
            };

            publisher.Publish(startEvent);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Test()
        {
            var right = Guid.NewGuid();
            var question = new DMMultipleChoiceQuestion()
            {
                Id = Guid.Empty,
                Options = new List<DMAnswerOption>()
                {
                    new DMAnswerOption()
                    {
                        Id = right,
                        Text = "1"
                    },
                     new DMAnswerOption()
                    {
                        Id = Guid.NewGuid(),
                        Text = "2"
                    },
                      new DMAnswerOption()
                    {
                        Id = Guid.NewGuid(),
                        Text = "М3"
                    },
                       new DMAnswerOption()
                    {
                        Id = Guid.NewGuid(),
                        Text = "4"
                    },
                },
                RightAnswerId = right,
                Text = "LOLKEK"
            };

            //Test
            //chatBot.SendQuestion(new List<int>() {
            //    459352140
            //}, question);

            return Ok();
        }
    }
}