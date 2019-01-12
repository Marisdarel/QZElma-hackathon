using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ChatBotService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace QZElma.Web.Controllers
{
    public class MessageController : ControllerBase
    {
        private readonly ChatBot chatBot;
        private readonly ILogger<MessageController> logger;
        private readonly ChatBotListener listener;

        public MessageController(ChatBot chatBot, ILogger<MessageController> logger, ChatBotListener listener)
        {
            this.chatBot = chatBot;
            this.logger = logger;
            this.listener = listener;
        }

    }
}