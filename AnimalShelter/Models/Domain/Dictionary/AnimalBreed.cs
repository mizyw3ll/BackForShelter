namespace AnimalShelter.Models.Domain.Dictionary
{
    public class AnimalBreed
    {
        //private AnimalBreed(Guid id, Guid animalViewId, string title)
        //{
        //    Id = id;
        //    AnimalViewId = animalViewId;
        //    Title = title;
        //}

        public Guid Id { get; set; }
        public Guid AnimalViewId { get; set; }
        public string Title { get; set; } = string.Empty;
        public AnimalView AnimalView { get; set; }

        //public static (AnimalBreed breed, string Error) Create(Guid id, Guid animalViewId, string title)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(title) || title.Length > 250)
        //        error = "Название пустое либо превышает 250 символов";

        //    var breed = new AnimalBreed(id, animalViewId, title);

        //    return (breed, error);
        //}
    }
}
