using ChatBotService.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ChatBotService
{
    public class ChatBot
    {
        private readonly string token;
        private readonly string hookUrl;
        private TelegramBotClient client;
        private readonly List<Command> commandList;

        public ChatBot(string token, string hookUrl)
        {
            this.token = token;
            this.hookUrl = hookUrl;
            this.commandList = new List<Command>()
            {
                new HelloComand()
            };
        }

        public async Task<TelegramBotClient> Get()
        {
            if(client != null)
            {
                return client;
            }

            client = new TelegramBotClient(token);
            await client.SetWebhookAsync(hookUrl);

            return client;
        }

        public List<Command> GetCommandList() => commandList;
    }
}
