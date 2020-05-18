using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoboblocksWebAPI.Models
{
    public class LevelTopScore
    {
        public long Id { get; set; }
        public float Complition_time { get; set; }
       // public float Blocks_used { get; set; }
        public long LevelId { get; set; }
        public string User { get; set; }
    }
}
