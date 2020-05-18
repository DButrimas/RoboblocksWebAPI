using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RoboblocksWebAPI.Models
{
    public class Waypoint
    {
        public long Id { get; set; }
        public float posX { get; set; }
        public float posY { get; set; }
        public float posZ { get; set; }

        public string LevelName { get; set; }
        public int ObjectId { get; set; }
    }
}
