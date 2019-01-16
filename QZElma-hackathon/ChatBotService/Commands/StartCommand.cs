using QZElma.Server.Management.EventPublishers.Interfaces;
using QZElma.Server.Models.Database.EventModels.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBotService.Commands
{
    public class StartCommand : Command
    {
        private readonly IEventPublisher publish;

        public StartCommand(IEventPublisher publish)
        {
            this.publish = publish;
        }

        public override string Name => "startquiz";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var ansEvent = new EventQuizStarted()
            {
                RoomId = Guid.Parse("4d2376a6-e3cd-452b-8ad4-f8457db3f0cd")
            };

            publish.Publish(ansEvent);
        }
    }
}
