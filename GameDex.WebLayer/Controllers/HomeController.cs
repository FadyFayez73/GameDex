using Application.Features.Games.Queries.Commands;
using GameDex.WebLayer.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics;

namespace GameDex.WebLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var game = await _mediator.Send(new GetGameByIdCommand(new Guid("EC0FF6B8-60A0-46F1-817D-A4B0A3B1BA97")));
            return View(game);
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
