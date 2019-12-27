using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Lab5.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab5.Controllers
{
    [Route("api/[controller]")]
    public class PhonesController : Controller
    {
        PhonesContext db;

        public PhonesController(PhonesContext context)
        {
            db = context;

            if (!db.Phones.Any())
            {
                db.Phones.Add(new Phones { Name = "Huawei p20 pro", Brend = "Huawei", Price = 1290.00m });
                db.Phones.Add(new Phones { Name = "Iphone 7", Brend = "Apple inc.", Price = 990.00m });
                db.Phones.Add(new Phones { Name = "Xiaomi Redmi 5", Brend = "Xiaomi", Price = 349.00m });
                db.SaveChanges();
            }
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phones>>> Get()
        {
            return await db.Phones.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phones>> Get(int id)
        {
            var phone = await db.Phones.FirstOrDefaultAsync(x => x.Id == id);

            if (phone == null)
            {
                return NotFound();
            }

            return new ObjectResult(phone);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Phones>> Post([FromBody] Phones phone)
        {
            if (phone == null)
            {
                return BadRequest();
            }

            db.Phones.Add(phone);
            await db.SaveChangesAsync();

            return Ok(phone);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Phones>> Put([FromBody] Phones phone)
        {
            if (phone == null)
            {
                return BadRequest();
            }

            if (!db.Phones.Any(x => x.Id == phone.Id))
            {
                return NotFound();
            }

            db.Update(phone);
            await db.SaveChangesAsync();

            return Ok(phone);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Phones>> Delete(int id)
        {
            var phone = db.Phones.FirstOrDefault(x => x.Id == id);

            if (phone == null)
            {
                return NotFound();
            }

            db.Phones.Remove(phone);
            await db.SaveChangesAsync();

            return Ok(phone);
        }
    }
}
