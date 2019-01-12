using ChatBotService.Commands;
using Microsoft.Extensions.Configuration;
using QZElma.Server.ConfigurationOptions;
using QZElma.Server.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ChatBotService
{
    [ChatBotServiceAtt]
    public class ChatBot
    {
        private readonly string token;
        private readonly string hookUrl;
        private TelegramBotClient client;
        private readonly List<Command> commandList;

        public ChatBot(IConfiguration configuration)
        {
            var botSettings = new BotSettings();
            configuration.GetSection("BotSettings").Bind(botSettings);

            this.token = botSettings.Token;
            this.hookUrl = botSettings.HoockUrl;

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
