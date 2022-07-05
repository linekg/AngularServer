using AngularSchoolServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularSchoolServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly Context db;
        public LessonsController(Context _db)
        {
            db = _db;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await db.Lessons.FirstOrDefaultAsync(a => a.ID == id));
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await db.Lessons.Include(a=>a.Teacher).AsSplitQuery().AsNoTracking().ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Lesson model)
        {
            db.Lessons.Add(model);
            await db.SaveChangesAsync();
            return Ok(model);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Lesson model)
        {
            db.Entry(model).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = db.Lessons.FirstOrDefault(x => x.ID == id);
            if(model is not null)
            {
                db.Lessons.Remove(model);
                await db.SaveChangesAsync();
            }
            
            return Ok(model);
        }
    }
}
