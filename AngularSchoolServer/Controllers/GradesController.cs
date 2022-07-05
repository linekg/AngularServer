using AngularSchoolServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularSchoolServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly Context db;
        public GradesController(Context _db)
        {
            db = _db;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await db.Grades.FirstOrDefaultAsync(a => a.ID == id));
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await db.Grades.AsSplitQuery().AsNoTracking().ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Grade model)
        {
            db.Grades.Add(model);
            await db.SaveChangesAsync();
            return Ok(model);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Grade model)
        {
            db.Entry(model).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = db.Grades.FirstOrDefault(x => x.ID == id);
            if(model is not null)
            {
                db.Grades.Remove(model);
                await db.SaveChangesAsync();
            }
            
            return Ok(model);
        }
    }
}
