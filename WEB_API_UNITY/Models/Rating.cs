using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoboblocksWebAPI.Models
{
    public class Rating
    {
        public long Id { get; set; }
        public float User_rating { get; set; }
        public long LevelId { get; set; }
        public long UserId { get; set; }
    }
}
