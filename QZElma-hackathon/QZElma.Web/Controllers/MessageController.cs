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
                Id = Guid.Parse("2b2c8ad8-f1f7-425c-a9fb-3ef0f54f247b"),
                Options = new List<DMAnswerOption>()
                {
                    new DMAnswerOption()
                    {
                        Id = Guid.Parse("c4730179-a900-4192-bf94-a82b3f78cb36"),
                        Text = "1"
                    },
                     new DMAnswerOption()
                    {
                        Id = Guid.Parse("08593bc9-7287-4e1e-b076-15fda9310755"),
                        Text = "2"
                    },
                      new DMAnswerOption()
                    {
                        Id = Guid.Parse("27b22573-931f-4cf5-b132-55624a799437"),
                        Text = "М3"
                    },
                       new DMAnswerOption()
                    {
                        Id = Guid.Parse("f11200cb-4be7-4de3-8c83-a9c38da546f0"),
                        Text = "4"
                    },
                },
                RightAnswerId = Guid.Parse("08593bc9-7287-4e1e-b076-15fda9310755"),
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