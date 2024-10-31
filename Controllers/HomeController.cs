using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models;
using MVCStartApp.Repos;
using System.Diagnostics;

namespace MVCStartApp.Controllers
{
    public class HomeController : Controller
    {
        // ссылка на репозиторий
        private readonly IBlogRepository _repo;
        private readonly ILogger<HomeController> _logger;

        // Также добавим инициализацию в конструктор
        public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
    }
}
