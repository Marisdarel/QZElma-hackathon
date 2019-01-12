using Microsoft.AspNetCore.Mvc;
using QZElma.Web.Models;
using System.Collections.Generic;
using System.Diagnostics;


namespace QZElma.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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
