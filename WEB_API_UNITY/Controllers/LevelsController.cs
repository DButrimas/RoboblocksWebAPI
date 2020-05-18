using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboblocksWebAPI.Data;
using RoboblocksWebAPI.Models;
using RoboblocksWebAPI.ViewModels;
using Object = RoboblocksWebAPI.Models.Object;

namespace RoboblocksWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LevelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("postScore/{id}")]
        public async Task<ActionResult> PostTopLevelScore(long id, LevelTopScore model)
        {

            LevelTopScore curr = _context.TopLevelScores.Where(x => x.LevelId == model.LevelId).FirstOrDefault();
            if (curr == null)
            {
                _context.Add(model);
                _context.SaveChanges();
                Response.WriteAsync("new");
                return Ok();

            }

            if (curr.Complition_time < model.Complition_time)
            {
                return Ok("didnt change");
            }
            else
            {
                Response.WriteAsync("new");
                _context.TopLevelScores.Remove(curr);
                _context.Add(model);
            }
            _context.SaveChanges();
            return Ok("new high score");
        }

        // GET: api/Levels/5
        [HttpGet("getHighScore/{id}")]
        public async Task<ActionResult<LevelTopScore>> GetHighScore(long id)
        {
            var level = await _context.TopLevelScores.Where(x => x.LevelId == id).FirstOrDefaultAsync();

            if (level == null)
            {
                Response.WriteAsync("not found");
                return NotFound();
            }

            return level;
        }


        // GET: api/Levels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Level>>> GetLevels()
        {
            List<Level> levels = _context.Levels.ToList();
            foreach (Level level in levels)
            {
                List<Rating> ratings = _context.Ratings.Where(x => x.LevelId == level.Id).ToList();
                float rating = 0;
                foreach (Rating item in ratings)
                {
                    rating += item.User_rating;
                }
                if (ratings.Count() > 0)
                {
                    rating = rating / ratings.Count();

                }
                else
                {
                    rating = 0;
                }
               
                level.Rating = (float)Math.Round(rating);
                level.Ratings = null;
            }



            return levels;
        }

        [HttpPost("waypoints")]
        public async Task<ActionResult<WaypointsModel>> PostWaypoints(WaypointsModel model)
        {
            Level lvlId = _context.Levels.Where(x => x.Name == model.LevelName).FirstOrDefault();
            Object enemy = _context.Objects.Where(x => x.Name.Contains("tank")).Where(x => x.LevelId == lvlId.Id).FirstOrDefault();
            if (enemy != null)
            {
                int id = (int)enemy.Id;
                foreach (Waypoint item in model.waypoints)
                {
                    item.ObjectId = id;
                    item.LevelName = model.LevelName;
                    _context.Waypoints.Add(item);
                }
            }
            else
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();



            return Ok();
        }


        [HttpPost("rateLevel/{id}")]
        public async Task<ActionResult> PostLevelRating(long id, RatingModel model)
        {

            Rating r = new Rating();
            r.LevelId = model.LevelId;
            r.UserId = _context.Users.Where(x => x.Username == model.User).FirstOrDefault().Id;
            r.User_rating = model.User_rating;

            _context.Ratings.Add(r);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPost("tankproperties")]
        public async Task<ActionResult<WaypointsModel>> PostTankProperties(TankProperties model)
        {

            Level lvlId = _context.Levels.Where(x => x.Name == model.levelName).FirstOrDefault();

            Object enemy = _context.Objects.Where(x => x.Name.Contains("tank")).Where(x => x.LevelId == lvlId.Id).FirstOrDefault();

            if (enemy != null)
            {
                model.levelId = lvlId.Id;
                _context.TankProperties.Add(model);
            }
            else
            {
                return NotFound();
            }
            await _context.SaveChangesAsync();



            return Ok();
        }

        [HttpGet("tankproperties/{name}")]
        public async Task<ActionResult<IEnumerable<TankProperties>>> GetLevelTankProperties(string name)
        {
            Level lvlId = _context.Levels.Where(x => x.Name == name).FirstOrDefault();


            return await _context.TankProperties.Where(x => x.levelId == lvlId.Id).ToListAsync();
        }


        [HttpGet("levelWaypoints/{id}")]
        public async Task<ActionResult<IEnumerable<Waypoint>>> GetLevelWaypoints(long id)
        {
            Level lvlId = _context.Levels.Where(x => x.Id == id).FirstOrDefault();

            return await _context.Waypoints.Where(x => x.LevelName == lvlId.Name).ToListAsync();
        }


        [HttpGet("levelObjects/{id}")]
        public async Task<ActionResult<IEnumerable<Object>>> GetLevelObjects(long id)
        {


            return await _context.Objects.Where(x => x.LevelId == id).ToListAsync();
        }

        // GET: api/Levels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Level>> GetLevel(long id)
        {
            var level = await _context.Levels.FindAsync(id);

            if (level == null)
            {
                return NotFound();
            }

            return level;
        }

        // PUT: api/Levels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevel(long id, Level level)
        {
            if (id != level.Id)
            {
                return BadRequest();
            }

            _context.Entry(level).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Levels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Level>> PostLevel(LevelSaveModel model)
        {
            int a = 0;
            Level level = new Level();
            level.Date = DateTime.Now;
            level.Description = model.description;
            level.Name = model.name;
            level.Objects = model.objects;

            User user = _context.Users.Where(u => u.Username == model.user).FirstOrDefault();
            if (user != null)
            {
                level.User = user;
                level.Username = user.Username;
            }


            _context.Levels.Add(level);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLevel", new { id = level.Id }, level);
        }

        // DELETE: api/Levels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Level>> DeleteLevel(long id)
        {
            var level = await _context.Levels.FindAsync(id);
            if (level == null)
            {
                return NotFound();
            }

            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();

            return level;
        }

        private bool LevelExists(long id)
        {
            return _context.Levels.Any(e => e.Id == id);
        }
    }
}
