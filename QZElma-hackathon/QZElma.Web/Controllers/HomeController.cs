using Microsoft.AspNetCore.Mvc;
using QZElma.Server.Management.EventPublishers.Interfaces;
using QZElma.Server.Models.Database.EventModels.Events;
using QZElma.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace QZElma.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventPublisher _eventPublisher;

        public HomeController(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public IActionResult Index()
        {
            //<Test
            _eventPublisher.Publish( new EventRoomCreated() {
                UserChatId = 2342
            } );
            //Test>

            var model = new List<LeaderBoardViewModel>()
            {
                new LeaderBoardViewModel()
                {
                    RightAnswerCount = 3,
                    UserName = "Вася пупкин"
                },
                new LeaderBoardViewModel()
                {
                    RightAnswerCount = 10,
                    UserName = "Велисовский эволенд"
                }
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
