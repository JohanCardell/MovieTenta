using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibrary
{
    public interface IMovieHandler
    {
        List<string> CreateTitlesList(List<IMovie> movies);
        List<IMovie> OrderMoviesBasedOnRating(bool ascending, List<IMovie> unsortedMovies);
        List<IMovie> RemoveDuplicates(List<IMovie> movies, List<IMovie> detailedMovies);
    }
}