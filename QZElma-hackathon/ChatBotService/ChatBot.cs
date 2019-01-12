﻿using ChatBotService.Commands;
using Microsoft.Extensions.Configuration;
using MihaZupan;
using QZElma.Server.ConfigurationOptions;
using QZElma.Server.Models.DatabaseModels.DMEntities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json.Linq;
using System;
using QZElma.Server.Management.EventPublishers.Interfaces;

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

        public ChatBot(IConfiguration configuration, IEventPublisher publisher)
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
                new HelloComand(),
                new UserEntireToRoom(publisher),
                new AnswerCommand(publisher)
            };
        }

        public async void SendQuestion(List<int> userList, DMMultipleChoiceQuestion question)
        {
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

            foreach(var user in userList)
            {
                await client.SendTextMessageAsync(
                user,
                question.Text,
                replyMarkup: rkm);
            }
            
        }

        public async void SendMessage(string message, int chatId)
        {
            await client.SendTextMessageAsync(chatId, message);
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
