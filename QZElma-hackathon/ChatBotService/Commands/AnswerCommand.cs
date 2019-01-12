using QZElma.Server.Management.EventPublishers.Interfaces;
using QZElma.Server.Models.Database.EventModels.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBotService.Commands
{
    public class AnswerCommand : Command
    {
        private readonly IEventPublisher publish;

        public AnswerCommand(IEventPublisher publish)
        {
            this.publish = publish;
        }

        public override string Name => "Answer";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var ansEvent = new EventUserAnsweredQuestion()
            {
                UserChatId = message.Chat.Id,
                AnswerText = message.Text
            };
            publish.Publish(ansEvent);
        }
    }
}
