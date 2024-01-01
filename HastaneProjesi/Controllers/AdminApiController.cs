using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HastaneProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaneProjesi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminApiController : ControllerBase
	{
		Context c = new Context();

		[HttpGet]
		public List<Admin> GetAdmin()
		{
			return c.Admins.ToList();
		}

		[HttpGet("{id}")]
		public Admin GetAdmin(int id)
		{
			var y = c.Admins.FirstOrDefault(x=>x.AdminID == id);
			return y;
		}

		[HttpPost]
		public void Post([FromBody] Admin y)
		{
			c.Admins.Add(y);
			c.SaveChanges();
		}

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Admin y) 
		{
			var y1 = c.Admins.FirstOrDefault(x=>x.AdminID==id);
			if(y1 is null)
			{
				return NotFound();
			}
			else
			{
				y1.UserName = y.UserName;
				y1.Password = y.Password;
				c.Update(y1);
				c.SaveChanges();
				return Ok();
			}
		}

        [HttpDelete("{id}")]
        public async Task<ActionResult<Admin>> DeleteAdmin(string id)
        {
			Context c = new Context();
            var admin = await c.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            

            c.Admins.Remove(admin);
            await c.SaveChangesAsync();

            return Ok(admin);
        }


    }
}
