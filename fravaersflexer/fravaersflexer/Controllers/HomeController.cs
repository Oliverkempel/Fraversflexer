﻿using System;
using System.Linq;
using fravaersflexer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Collections.Generic;
using fravaersflexer.Data;
using System.Dynamic;

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

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewData["AgeSortParm"] = sortOrder == "Age" ? "Age_desc" : "Age";
            ViewData["SchoolSortParm"] = sortOrder == "School" ? "School_desc" : "School";
            ViewData["EducationSortParm"] = sortOrder == "Education" ? "Education_desc" : "Education";
            ViewData["ClassSortParm"] = sortOrder == "Class" ? "Class_desc" : "Class";
            ViewData["AbsenceSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Absence_desc" : "";
            var persons = from s in this.Context.Person select s;


            //List<Person> persons = (from person in this.Context.Person.Take(10) select person).ToList();
            //List<Person> persons = new List<Person> 
            //{ 
            //    new Person() { Age = 12, Name = "Mads", SchoolName = "College360", ClassName = "3X", EducationName = "HTX", AbsencePercentage = 20 },
            //    new Person() { Age = 12, Name = "Morten", SchoolName = "Silkeborg Gym", ClassName = "2K", EducationName = "STX", AbsencePercentage = 3 },
            //    new Person() { Age = 12, Name = "William", SchoolName = "Rudolf steiner skolen", ClassName = "3X", EducationName = "HHX", AbsencePercentage = 34 },
            //    new Person() { Age = 12, Name = "Jens", SchoolName = "T.H Langs", ClassName = "1H", EducationName = "HF", AbsencePercentage = 65 },
            //    new Person() { Age = 12, Name = "Kurt", SchoolName = "Silkeborg Gym", ClassName = "3J", EducationName = "STX", AbsencePercentage = 12 },
            //    new Person() { Age = 12, Name = "Gorm", SchoolName = "College360", ClassName = "2XY", EducationName = "HTX", AbsencePercentage = 6 } 
            //};
            switch (sortOrder)
            {
                case "Name":
                    persons = persons.OrderBy(s => s.Name);
                    break;
                case "Name_desc":
                    persons = persons.OrderByDescending(s => s.Name);
                    break;
                case "Age":
                    persons = persons.OrderBy(s => s.Age);
                    break;
                case "Age_desc":
                    persons = persons.OrderByDescending(s => s.Age);
                    break;
                case "School":
                    persons = persons.OrderBy(s => s.ClassName);
                    break;
                case "School_desc":
                    persons = persons.OrderByDescending(s => s.ClassName);
                    break;
                case "Education":
                    persons = persons.OrderBy(s => s.EducationName);
                    break;
                case "Education_desc":
                    persons = persons.OrderByDescending(s => s.EducationName);
                    break;
                case "Class":
                    persons = persons.OrderBy(s => s.ClassName);
                    break;
                case "Class_desc":
                    persons = persons.OrderByDescending(s => s.ClassName);
                    break;
                case "Absence_desc":
                    persons = persons.OrderByDescending(s => s.AbsencePercentage);
                    break;
                default:
                    persons = persons.OrderBy(s => s.AbsencePercentage);
                    break;
            }
            //persons.Sort((x,y) => y.AbsencePercentage.CompareTo(x.AbsencePercentage));

            //Person firstPlacePerson = persons.OrderByDescending(x => x.AbsencePercentage).First();
            //Person secondPlacePerson = persons.OrderByDescending(x => x.AbsencePercentage).Skip(1).First();
            //Person thirdPlacePerson = persons.OrderByDescending(x => x.AbsencePercentage).Skip(2).First();

            Person firstPlacePerson = persons.OrderByDescending(x => x.AbsencePercentage).Last();
            Person secondPlacePerson = persons.OrderByDescending(x => x.AbsencePercentage).Reverse().Skip(1).First();
            Person thirdPlacePerson = persons.OrderByDescending(x => x.AbsencePercentage).Reverse().Skip(2).First();

            List<Person> leaderbordPersons = new List<Person>();
            leaderbordPersons.Add(firstPlacePerson);
            leaderbordPersons.Add(secondPlacePerson);
            leaderbordPersons.Add(thirdPlacePerson);

            ViewData["Winners"] = leaderbordPersons;
                var Educations = new List<string>()
                {
                        "STX",
                        "HHX",
                        "HTX",
                        "HF",
                        "EUX",
                        "EUD"                    
                    };
                IDictionary<string, int> Sum_Educations = new Dictionary<string, int>();
                var SUM_Edu = persons.Sum(s => s.AbsencePercentage);
                
                
                foreach (string item in Educations)
                {
                    if (persons.Where(s => s.EducationName.Equals(item)).Count() > 0)
                    {
                        double x = (double)persons.Where(s => s.EducationName.Equals(item)).Sum(s => s.AbsencePercentage)/persons.Where(s => s.EducationName.Equals(item)).Count();
                        Sum_Educations.Add(item, (int)x);
                    }
                    else 
                    {
                        Sum_Educations.Add(item, 0);
                    }
                }
                
                int MaxVal = Sum_Educations.Max(s => s.Value);

                double STX_P = 100*(double)Sum_Educations["STX"]/MaxVal;           
                double HHX_P = 100*(double)Sum_Educations["HHX"]/MaxVal;
                double HTX_P = 100*(double)Sum_Educations["HTX"]/MaxVal;
                double HF_P = 100*(double)Sum_Educations["HF"]/MaxVal;
                double EUX_P = 100*(double)Sum_Educations["EUX"]/MaxVal;
                double EUD_P = 100*(double)Sum_Educations["EUD"]/MaxVal;

                Sum_Educations.Add("MaxVal", (int)MaxVal);
                Sum_Educations.Add("STX_P", (int)STX_P);
                Sum_Educations.Add("HHX_P", (int)HHX_P);
                Sum_Educations.Add("HTX_P", (int)HTX_P);
                Sum_Educations.Add("HF_P",  (int)HF_P);
                Sum_Educations.Add("EUX_P", (int)EUX_P);
                Sum_Educations.Add("EUD_P", (int)EUD_P);

                ViewData["EducationData"] = Sum_Educations;


            return View(await persons.AsNoTracking().ToListAsync());
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