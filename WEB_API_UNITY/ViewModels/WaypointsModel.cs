using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoboblocksWebAPI.Models;

namespace RoboblocksWebAPI.ViewModels
{
    public class WaypointsModel
    {
        public List<Waypoint> waypoints { get; set; }
        public string LevelName { get; set; }

    }
}