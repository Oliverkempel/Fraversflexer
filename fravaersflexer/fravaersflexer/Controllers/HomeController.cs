using fravaersflexer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using fravaersflexer.Data;

namespace fravaersflexer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext Context { get; }

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _context)
        {
            _logger = logger;
            this.Context = _context;
        }

        public IActionResult Index()
        {
            //List<Person> persons = (from person in this.Context.Person.Take(10) select person).ToList();
            List<Person> persons = new List<Person> 
            { 
                new Person() { Age = 12, Name = "Mads", SchoolName = "College360", ClassName = "3X", EducationName = "HTX", AbsencePercentage = 20 },
                new Person() { Age = 12, Name = "Morten", SchoolName = "Silkeborg Gym", ClassName = "2K", EducationName = "STX", AbsencePercentage = 3 },
                new Person() { Age = 12, Name = "William", SchoolName = "Rudolf steiner skolen", ClassName = "3X", EducationName = "HHX", AbsencePercentage = 34 },
                new Person() { Age = 12, Name = "Jens", SchoolName = "T.H Langs", ClassName = "1H", EducationName = "HF", AbsencePercentage = 65 },
                new Person() { Age = 12, Name = "Kurt", SchoolName = "Silkeborg Gym", ClassName = "3J", EducationName = "STX", AbsencePercentage = 12 },
                new Person() { Age = 12, Name = "Gorm", SchoolName = "College360", ClassName = "2XY", EducationName = "HTX", AbsencePercentage = 6 } 
            };
            return View(persons);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAbsence([Bind("Id,Name,Age,EducationName,ClassName,SchoolName,AbsencePercentage")] Person person)
        {
            if (ModelState.IsValid)
            {
                Context.Add(person);
                await Context.SaveChangesAsync();
                return Redirect(nameof(Index));
            }   
            return Redirect(nameof(Register));
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}