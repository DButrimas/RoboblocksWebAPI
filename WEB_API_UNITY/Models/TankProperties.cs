using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoboblocksWebAPI.Models
{
    public class TankProperties
    {
        public long Id { get; set; }
        public long levelId { get; set; }

        public string levelName { get; set; }
        public float ShootingSpeed {get;set;}
        public float MovementSpeed { get; set; }
        public float BarrelRotationSpeed { get; set; }

        public float TriggerScale { get; set; }
    }
}
