using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatBotService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace QZElma.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ChatBot chatBot;

        public MessageController(ChatBot chatBot)
        {
            this.chatBot = chatBot;
        }

        public async Task<OkResult> Update(Update update)
        {
            var commands = chatBot.GetCommandList();
            var message = update.Message;
            var client = await chatBot.Get();

            var command = commands.FirstOrDefault(x => x.Contains(update.Message.Text));

            if(command != null)
            {
                command.Execute(message, client);
            }

            return Ok();
        }

    }
}