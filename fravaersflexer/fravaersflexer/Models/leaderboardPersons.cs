using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using fravaersflexer.Models;
using fravaersflexer.Data;

namespace fravaersflexer.Models
{
    public class leaderboardPersons
    {
        public Person firstPlace { get; set; }
        public Person secondPlace { get; set; }
        public Person thirdPlace { get; set; }
    }
}
