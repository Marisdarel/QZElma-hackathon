using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBotService.Commands
{
    public class UserEntireToRoom : Command
    {
        public override string Name => "Entry";

        public override void Execute(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
