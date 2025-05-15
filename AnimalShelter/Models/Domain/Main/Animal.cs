using AnimalShelter.Models.Domain.Dictionary;

namespace AnimalShelter.Models.Domain.Main
{
    public class Animal
    {
        //private Animal(Guid id, Guid viewId, bool isMale, int age,
        //    Guid breedId, string distinctiveFeatures, decimal weight,
        //    decimal height, string photos, Guid animalStatusId)
        //{
        //    Id = id;
        //    ViewId = viewId;
        //    IsMale = isMale;
        //    Age = age;
        //    BreedId = breedId;
        //    DistinctiveFeatures = distinctiveFeatures;
        //    Weight = weight;
        //    Height = height;
        //    Photos = photos;
        //    AnimalStatusId = animalStatusId;
        //}

        public Guid Id { get; set; }
        public Guid AnimalViewId { get; set; }
        public bool IsMale { get; set; }
        public int Age { get; set; }
        public Guid AnimalBreedId { get; set; }
        public string DistinctiveFeatures { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string Photos { get; set; } = string.Empty;
        public Guid AnimalStatusId { get; set; }

        // ключи

        public AnimalView AnimalView { get; set; }
        public AnimalBreed AnimalBreed { get; set; }
        public AnimalStatus AnimalStatus { get; set; }

        //public static (Animal Animal, string Error) Create(
        //    Guid id,
        //    Guid viewId,
        //    bool isMale,
        //    int age,
        //    Guid breedId,
        //    string distinctiveFeatures,
        //    decimal weight,
        //    decimal height,
        //    string photos,
        //    Guid animalStatusId
        //    )
        //{
        //    // нужно добавить вывод на ошибки
        //    var error = string.Empty;

        //    var animal = new Animal(id, viewId, isMale, age,
        //        breedId, distinctiveFeatures, weight, height,
        //        photos, animalStatusId);

        //    return (animal, error);
        //}
    }
}
