using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ChatBotService.Commands
{
    public class HelloComand : Command
    {
        public override string Name => "hellobot";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            
            await client.SendTextMessageAsync(0, "Hello", replyToMessageId: messageId);
        }
    }
}
