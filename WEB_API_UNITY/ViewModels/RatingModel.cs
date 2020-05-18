using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoboblocksWebAPI.ViewModels
{
    public class RatingModel
    {
        public float User_rating { get; set; }
        public long LevelId { get; set; }
        public string User { get; set; }
    }
}
