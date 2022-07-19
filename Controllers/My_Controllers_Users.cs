using My_Practice_Work.Data;
using My_Practice_Work.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace My_PracticeWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class My_Controllers_Users : ControllerBase
    {
        Users_Work db;
        public My_Controllers_Users(Users_Work context)
        {
            db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new Person
                {
                });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            return await db.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            Person? user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task<ActionResult<Person>> Post(Person Human)
        {
            if (Human == null)
            {
                return BadRequest();
            }
            db.Users.Add(Human);;
            await db.SaveChangesAsync();
            return Ok(Human);
        }
        [HttpPut]
        public async Task<ActionResult<Person>> Put(Person Human)
        {
            if (Human == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == Human.Id))
            {
                return NotFound();
            }
            db.Update(Human);
            await db.SaveChangesAsync();
            return Ok(Human);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> Delete(int id)
        {
            Person? user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
