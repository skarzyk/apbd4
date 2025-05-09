using Tutorial6.Models;

namespace Tutorial6;

public static class Database
{
    
        public static List<Animal> Animals { get; } = new List<Animal>
        {
            new Animal { Id = 1, Name = "Maks", Category = "pies", Weight = 12.5, FurColor = "brązowy" },
            new Animal { Id = 2, Name = "Gerth", Category = "kot", Weight = 4.3,  FurColor = "czarny" },
            new Animal { Id = 3, Name = "Nutella", Category = "pies", Weight = 16.3 ,  FurColor = "biały" }
        };
        
        public static List<Visit> Visits { get; } = new List<Visit>
        {
            new Visit { Id = 1, AnimalId = 1, Date = DateTime.Parse("2025-05-01"), Description = "Szczepienie", Price = 50m },
            new Visit { Id = 2, AnimalId = 2, Date = DateTime.Parse("2025-05-03"), Description = "Odrobaczanie", Price = 30m }
        };
    
}