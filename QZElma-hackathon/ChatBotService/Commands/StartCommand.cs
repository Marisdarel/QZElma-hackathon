using QZElma.Server.Management.EventPublishers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBotService.Commands
{
    public class StartCommand : Command
    {
        private readonly IEventPublisher publisher;

        public StartCommand(IEventPublisher publisher)
        {
            this.publisher = publisher;
        }

        public override string Name => "StartGame";

        public override void Execute(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
