using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    [Route("api/animals/{animalId}/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        // 1) GET api/animals/{animalId}/visits
        [HttpGet]
        public IActionResult GetForAnimal(int animalId)
        {
            var exists = Database.Animals.Any(x => x.Id == animalId);
            if (!exists) return NotFound($"Animal {animalId} not found.");

            var visits = Database.Visits
                .Where(v => v.AnimalId == animalId)
                .ToList();
            return Ok(visits);
        }

        // 2) POST api/animals/{animalId}/visits
        [HttpPost]
        public IActionResult Create(int animalId, [FromBody] Visit visit)
        {
            var exists = Database.Animals.Any(x => x.Id == animalId);
            if (!exists) return NotFound($"Animal {animalId} not found.");
            
            var nextId = Database.Visits.Any() 
                ? Database.Visits.Max(x => x.Id) + 1 
                : 1;
            visit.Id = nextId;
            visit.AnimalId = animalId;
            Database.Visits.Add(visit);

            return CreatedAtAction(
                nameof(GetForAnimal),
                new { animalId = animalId },
                visit
            );
        }
    }
}