using DapperMvc.Models;
using Database.Models.Domain;
using Database.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace DapperMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonRepository _repo;
        public HomeController(ILogger<HomeController> logger , IPersonRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var people = await _repo.GetAllAsync();
            return View(people);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            if (ModelState.IsValid)
            {
                bool result = await _repo.AddAsync(person);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View(person);
            }
            else
                return RedirectToAction(nameof(Add)); ;
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
