using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoboblocksWebAPI.Models;
using Object = RoboblocksWebAPI.Models.Object;

namespace RoboblocksWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Level> Levels { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Waypoint> Waypoints { get; set; }
        public DbSet<TankProperties> TankProperties { get; set; }
        public DbSet<LevelTopScore> TopLevelScores { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           // Database.EnsureCreated();
        }
    }
}
