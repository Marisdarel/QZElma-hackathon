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
using Newtonsoft.Json.Linq;

namespace ChatBotService
{
    [QZElma.Server.Models.Attributes.ChatBotService]
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

        public async void Question(int roomId, DMMultipleChoiceQuestion question)
        {
            var right = Guid.NewGuid();
            question = new DMMultipleChoiceQuestion()
            {
                Id = Guid.Empty,
                Options = new List<DMAnswerOption>()
                {
                    new DMAnswerOption()
                    {
                        Id = right,
                        Text = "1"
                    },
                     new DMAnswerOption()
                    {
                        Id = Guid.NewGuid(),
                        Text = "2"
                    },
                      new DMAnswerOption()
                    {
                        Id = Guid.NewGuid(),
                        Text = "М3"
                    },
                       new DMAnswerOption()
                    {
                        Id = Guid.NewGuid(),
                        Text = "4"
                    },
                },
                RightAnswerId = right,
                Text = "LOLKEK"
            };

            var keyboard = new ReplyKeyboardMarkup();

            
            var rows = new List<InlineKeyboardButton[]>();
            var cols = new List<InlineKeyboardButton>();

            for (var i = 0; i < question.Options.Count(); i++)
            {
                cols.Add(InlineKeyboardButton.WithCallbackData(question.Options.ElementAt(i).Text, question.Options.ElementAt(i).Id.ToString()));
                if (i % 2 != 0) continue;
                rows.Add(cols.ToArray());
                cols = new List<InlineKeyboardButton>();
            }

            var rkm = new InlineKeyboardMarkup(rows.ToArray());

            await client.SendTextMessageAsync(
                459352140,
                question.Text,
                replyMarkup: rkm);
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
