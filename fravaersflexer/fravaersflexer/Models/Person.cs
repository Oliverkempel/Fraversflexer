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
        public string Surname { get; set; }
        public int Cocklength { get; set; }
        public string Klasse { get; set; }
        public int Alder { get; set; }
        public string Email { get; set; }
    }
}