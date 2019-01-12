using ChatBotService;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        private Timer _timer;
        int offset = 0;
        

        public ChatBotListener(ChatBot bot, ILogger<ChatBotListener> logger)
        {
            this.logger = logger;
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

                    if (message == null)
                        continue;

                    var command = commands.FirstOrDefault(x => x.Contains(message.Text));

                    if (command != null)
                    {
                        command.Execute(message, client);
                        logger.LogInformation("Execute command {0}", update.Message.Text);
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
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(100000));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
