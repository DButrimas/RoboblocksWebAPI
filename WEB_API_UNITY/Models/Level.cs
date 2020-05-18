using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoboblocksWebAPI.Models
{
    public class Level
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }
        public ICollection<Object> Objects { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public User User { get; set; }

        public float Rating { get; set; }

        public string Username { get; set; }
    }
}
