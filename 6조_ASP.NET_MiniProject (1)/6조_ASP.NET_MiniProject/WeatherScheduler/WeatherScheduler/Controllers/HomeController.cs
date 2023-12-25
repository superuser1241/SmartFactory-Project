using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WeatherScheduler.Models;

namespace WeatherScheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public class IndexViewModel
        {
            public List<City> Cities { get; set; }
            public List<Schedule> Schedules { get; set; }
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = _db.Schedules
                .FirstOrDefault(m => m.No == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var schedule = _db.Schedules.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _db.Schedules.Remove(schedule);
            _db.SaveChanges();

            return RedirectToAction(nameof(Management));
        }
        public async Task<IActionResult> Management()
        {
            var schedules = await _db.Schedules.ToListAsync<Schedule>();
            return View(schedules);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Schedule Sc)
        {
            if (ModelState.IsValid)
            {
                await _db.Schedules.AddAsync(Sc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Management", "Home");
            }
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var cities = await _db.Cities.ToListAsync<City>();
            var schedules = await _db.Schedules.ToListAsync<Schedule>();

            var viewModel = new IndexViewModel
            {
                Cities = cities,
                Schedules = schedules
            };

            return View(viewModel);
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