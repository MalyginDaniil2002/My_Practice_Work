using My_Practice_Work.Data;
using My_Practice_Work.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<Worker>> Post(Worker list)
        {
            if (list == null)
            {
                return BadRequest();
            }
            db.Workers.Add(list);
            await db.SaveChangesAsync();
            return Ok(list);
        }
        [HttpPut]
        public async Task<ActionResult<Worker>> Put(Worker list)
        {
            if (list == null)
            {
                return BadRequest();
            }
            if (!db.Workers.Any(x => x.Id == list.Id))
            {
                return NotFound();
            }
            db.Update(list);
            await db.SaveChangesAsync();
            return Ok(list);
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
