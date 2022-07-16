using Microsoft.EntityFrameworkCore;
using My_PracticeWork.Models;
using Microsoft.AspNetCore.Mvc;
namespace My_PracticeWork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class My_Controllers : ControllerBase
    {
        Users_Work db;
        public My_Controllers(Users_Work context)
        {
            db = context;
            if (!db.Users.Any())
            {
                db.Users.Add(new Person
                {
                    Name = "Daniil",
                    Surname = "Malygin",
                    Middle_Name = "Alexandrovich",
                    Birth_Year = 2002,
                    Birth_Month = 3,
                    Birth_Day = 14
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
        public async Task<ActionResult<Person>> Post(Person user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut]
        public async Task<ActionResult<Person>> Put(Person user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
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
