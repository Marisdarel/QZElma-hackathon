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
            chatBot.Question(0, null);

            return Ok();
        }
    }
}