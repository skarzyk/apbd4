using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        // 1) GET api/animals
        [HttpGet]
        public IActionResult GetAll()
            => Ok(Database.Animals);

        // 2) GET api/animals/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var a = Database.Animals.FirstOrDefault(x => x.Id == id);
            if (a == null) return NotFound();
            return Ok(a);
        }

        // 6) wyszukiwanie po imieniu: GET api/animals/search?name=bur
        [HttpGet("search")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            var list = Database.Animals
                .Where(x => x.Name.Contains(name, System.StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Ok(list);
        }

        // 3) POST api/animals
        [HttpPost]
        public IActionResult Create([FromBody] Animal animal)
        {
            var nextId = Database.Animals.Max(x => x.Id) + 1;
            animal.Id = nextId;
            Database.Animals.Add(animal);
            return CreatedAtAction(nameof(GetById), new { id = animal.Id }, animal);
        }

        // 4) PUT api/animals/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Animal updated)
        {
            var a = Database.Animals.FirstOrDefault(x => x.Id == id);
            if (a == null) return NotFound();

            a.Name     = updated.Name;
            a.Category = updated.Category;
            a.Weight   = updated.Weight;
            a.FurColor = updated.FurColor;
            return NoContent();
        }

        // 5) DELETE api/animals/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var a = Database.Animals.FirstOrDefault(x => x.Id == id);
            if (a == null) return NotFound();
            Database.Animals.Remove(a);
            return NoContent();
        }
    }
}
