using QZElma.Server.Management.EventPublishers.Interfaces;
using QZElma.Server.Models.Database.EventModels.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBotService.Commands
{
    public class UserEntireToRoom : Command
    {
        private readonly IEventPublisher publisher;

        public UserEntireToRoom(IEventPublisher publisher)
        {
            this.publisher = publisher;
        }

        public override string Name => "entry";

        public async override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;

            var entryEvent = new EventUserEnteredRoom() {
                UserChatId = chatId,
                RoomId = Guid.Empty
            };

            publisher.Publish(entryEvent);

            await client.SendTextMessageAsync(chatId, "Вы зашли в комнату, ожидайте начала игры");
        }
    }
}
