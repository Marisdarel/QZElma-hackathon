using ChatBotService.Commands;
using Microsoft.Extensions.Configuration;
using MihaZupan;
using QZElma.Server.ConfigurationOptions;
using QZElma.Server.Models.Attributes;
using QZElma.Server.Models.DatabaseModels.DMEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using LinqKit;
using System.Linq;

namespace ChatBotService
{
    [ChatBotServiceAtt]
    public class ChatBot
    {
        private readonly string token;
        private readonly string hookUrl;
        private readonly string socks5Host;
        private readonly int socks5Port;
        private readonly string socks5User;
        private readonly string socks5Pass;
        private TelegramBotClient client;
        private readonly List<Command> commandList;

        public ChatBot(IConfiguration configuration)
        {
            var botSettings = new BotSettings();
            configuration.GetSection("BotSettings").Bind(botSettings);

            this.token = botSettings.Token;
            this.hookUrl = botSettings.HoockUrl;
            this.socks5Host = botSettings.Socks5Host;
            this.socks5Port = botSettings.Socks5Port;
            this.socks5User = botSettings.Socks5User;
            this.socks5Pass = botSettings.Socks5Pass;

            this.commandList = new List<Command>()
            {
                new HelloComand()
            };
        }

        public void Question(int roomId, DMMultipleChoiceQuestion question)
        {
            var keyboard = new ReplyKeyboardMarkup();

            var rkm = new ReplyKeyboardMarkup();
            var rows = new List<KeyboardButton[]>();
            var cols = new List<KeyboardButton>();
            for (var i = 0; i < question.Options.Count(); i++)
            {
                cols.Add(new KeyboardButton(question.Options.ElementAt(i).Text));
                if (i % 2 != 0) continue;
                rows.Add(cols.ToArray());
                cols = new List<KeyboardButton>();
            }
            rkm.Keyboard = rows.ToArray();


            //await client.SendTextMessageAsync(
            //    message.Chat.Id,
            //    "Choose",
            //    replyMarkup: rkm);
        }

        public async Task<TelegramBotClient> Get()
        {
            if(client != null)
            {
                return client;
            }

            client = new TelegramBotClient(token,
                new HttpToSocks5Proxy(socks5Host, socks5Port, socks5User, socks5Pass));

            return client;
        }

        public List<Command> GetCommandList() => commandList;
    }
}
