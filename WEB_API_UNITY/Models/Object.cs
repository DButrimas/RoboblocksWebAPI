using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoboblocksWebAPI.Models;

namespace RoboblocksWebAPI.Models
{
    public class Object
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float posX { get; set; }
        public float posY { get; set; }
        public float posZ { get; set; }
        public float rotationX { get; set; }
        public float rotationY { get; set; }
        public float rotationZ { get; set; }

        public float scaleX { get; set; }
        public float scaleY { get; set; }
        public float scaleZ { get; set; }


        public float r { get; set; }
        public float g { get; set; }
        public float b { get; set; }

        public long LevelId { get; set; }
    }
}
