using AngularSchoolServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularSchoolServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly Context db;
        public TeachersController(Context _db)
        {
            db = _db;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await db.Teachers.FirstOrDefaultAsync(a => a.ID == id));
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await db.Teachers.AsSplitQuery().AsNoTracking().ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Teacher model)
        {
            try
            {
                db.Teachers.Add(model);
                await db.SaveChangesAsync();
                return Ok(model);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Teacher model)
        {
            db.Entry(model).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = db.Teachers.FirstOrDefault(x => x.ID == id);
            if(teacher is not null)
            {
                db.Teachers.Remove(teacher);
                await db.SaveChangesAsync();
            }
            
            return Ok(teacher);
        }
    }
}
