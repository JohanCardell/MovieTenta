namespace MovieLibrary.Models
{
    public interface IMovie
    {
        string id { get; set; }
        string title { get; set; }
        string rated { get; set; }
    }
}