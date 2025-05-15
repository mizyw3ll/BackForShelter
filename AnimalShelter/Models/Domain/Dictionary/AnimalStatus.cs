namespace AnimalShelter.Models.Domain.Dictionary
{
    public class AnimalStatus
    {
        //private AnimalStatus(Guid id, string title)
        //{
        //    Id = id;
        //    Title = title;
        //}

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        //public static (AnimalStatus Status, string Error) Create(Guid id, string title)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(title) || title.Length > 250)
        //        error = "Название пустое либо превышает 250 символов";

        //    var animalStatus = new AnimalStatus(id, title);

        //    return (animalStatus, error);
        //}
    }
}
