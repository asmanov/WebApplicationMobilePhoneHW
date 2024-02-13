using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplicationMobilePhone.Model;

namespace WebApplicationMobilePhone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly List<Phone> _phones;

        public PhoneController()
        {
            // Инициализируем список телефонов
            _phones = new List<Phone>
            {
                new Phone { Id = 1, Name = "iPhone 12", Brand = "Apple", Price = 999.99 },
                new Phone { Id = 2, Name = "Galaxy S20", Brand = "Samsung", Price = 899.99 },
                new Phone { Id = 3, Name = "Pixel 5", Brand = "Google", Price = 699.99 }
            };
        }

        // GET: api/Phone
        [HttpGet]
        public ActionResult<IEnumerable<Phone>> Get()
        {
            return Ok(_phones);
        }

        // GET: api/Phone/5
        [HttpGet("{id}")]
        public ActionResult<Phone> Get(int id)
        {
            var phone = _phones.FirstOrDefault(p => p.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            return Ok(phone);
        }

        // POST: api/Phone
        [HttpPost]
        public ActionResult Post([FromBody] Phone phone)
        {
            if (phone == null)
            {
                return BadRequest("Phone object is null");
            }

            _phones.Add(phone);
            return CreatedAtAction(nameof(Get), new { id = phone.Id }, phone);
        }

        // PUT: api/Phone/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Phone phone)
        {
            if (phone == null || phone.Id != id)
            {
                return BadRequest("Invalid phone object");
            }

            var existingPhone = _phones.FirstOrDefault(p => p.Id == id);
            if (existingPhone == null)
            {
                return NotFound();
            }

            existingPhone.Name = phone.Name;
            existingPhone.Brand = phone.Brand;
            existingPhone.Price = phone.Price;

            return NoContent();
        }

        // DELETE: api/Phone/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var phone = _phones.FirstOrDefault(p => p.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            _phones.Remove(phone);
            return NoContent();
        }
    }

    
}

