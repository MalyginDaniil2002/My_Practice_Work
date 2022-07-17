using Microsoft.EntityFrameworkCore;
using My_Practice_Work.Data;
using My_Practice_Work.Models;
using Microsoft.AspNetCore.Mvc;
namespace My_Practice_Work.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class My_Controllers_Workers: ControllerBase
    {
        Workers_List db;
        public My_Controllers_Workers(Workers_List context)
        {
            db = context;
            if (!db.Workers.Any())
            {
                db.Workers.Add(new Worker
                {
                    Name = "Olga",
                    Age = 40
                });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worker>>> Get()
        {
            return await db.Workers.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Worker>> Get(int id)
        {
            Worker? user = await db.Workers.FirstOrDefaultAsync(y => y.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(user);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Worker>> Post(Worker user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            db.Workers.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut]
        public async Task<ActionResult<Worker>> Put(Worker user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Workers.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Worker>> Delete(int id)
        {
            Worker? user = db.Workers.FirstOrDefault(y => y.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Workers.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}