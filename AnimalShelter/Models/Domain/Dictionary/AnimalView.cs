namespace AnimalShelter.Models.Domain.Dictionary
{
    public class AnimalView
    {
        //private AnimalView(Guid id, string title)
        //{ 
        //    Id = id;
        //    Title = title;
        //}

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        //public static (AnimalView View, string Error) Create (Guid id, string title)
        //{
        //    var error = string.Empty;

        //    if (string.IsNullOrEmpty(title) || title.Length > 250)
        //        error = "Название пустое либо превышает 250 символов";

        //    var view = new AnimalView(id, title);

        //    return (view, error);
        //}
    }
}
