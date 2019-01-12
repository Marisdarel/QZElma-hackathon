using ChatBotService;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QZElma.Server.Management.EventPublishers.Interfaces;
using QZElma.Server.Models.Database.EventModels.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QZElma.Web
{
    public class ChatBotListener : IHostedService, IDisposable
    {
        private readonly ChatBot bot;
        private readonly ILogger<ChatBotListener> logger;
        private readonly IEventPublisher publisher;
        private Timer _timer;
        private int offset = 911858348;
        

        public ChatBotListener(ChatBot bot, ILogger<ChatBotListener> logger, IEventPublisher publisher)
        {
            this.logger = logger;
            this.publisher = publisher;
            this.bot = bot;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private async void DoWork(object sender)
        {
            try
            {
                var client = await bot.Get();
                var updates = await client.GetUpdatesAsync(offset); // получаем массив обновлений

                foreach (var update in updates) // Перебираем все обновления
                {
                    var commands = bot.GetCommandList();
                    var message = update.Message;
                    var callback = update.CallbackQuery;

                    if (message != null)
                    {
                        var command = commands.FirstOrDefault(x => x.Contains(message.Text));

                        if (command != null)
                        {
                            command.Execute(message, client);
                            logger.LogInformation("Execute command {0}", update.Message.Text);
                        }
                    }
                    else if(callback != null)
                    {
                        var command = commands.Where(x => x.Name == "Answer").FirstOrDefault();
                        if (command != null)
                        {
                            var answerEvent = new EventUserAnsweredQuestion() {
                                UserChatId = callback.From.Id,
                                AnswerId = callback.Data
                            };
                        }
                    }

                    offset = update.Id + 1;
                }


            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                logger.LogError(ex, "Error {0}", ex.Message);
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Лиссенер старнтанул");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
