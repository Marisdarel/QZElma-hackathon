using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBotService.Commands
{
    public class AnswerCommand : Command
    {
        public override string Name => "Answer";

        public override void Execute(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
