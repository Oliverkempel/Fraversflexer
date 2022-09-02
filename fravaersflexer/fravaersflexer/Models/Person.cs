using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using fravaersflexer.Models;
using fravaersflexer.Data;

namespace fravaersflexer.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string EducationName { get; set; }
        public string ClassName { get; set; }
        public string SchoolName { get; set; }
        public float AbsencePercentage { get; set; }
    }
}