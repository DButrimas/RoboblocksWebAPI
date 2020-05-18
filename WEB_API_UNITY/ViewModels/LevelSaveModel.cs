using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoboblocksWebAPI.Models;
using Object = RoboblocksWebAPI.Models.Object;

namespace RoboblocksWebAPI.ViewModels
{
    public class LevelSaveModel
    {
        public List<Object> objects { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public DateTime date { get; set; }

        public string user { get; set; }
    }
}
