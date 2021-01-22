using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieHandler : IMovieHandler
    {
        private readonly IMovieComparer _movieComparer;
        public MovieHandler(IMovieComparer movieComparer)
        {
            _movieComparer = movieComparer;
        }
        public List<IMovie> OrderMoviesBasedOnRating(bool ascending, List<IMovie> unsortedMovies)
        {
            if (unsortedMovies.Count > 0)
            {
                List<IMovie> sortedMovieList = new List<IMovie>();
                if (ascending)
                {
                    sortedMovieList = unsortedMovies.OrderBy(e => e.rated).ToList();
                }
                else
                {
                    sortedMovieList = sortedMovieList.OrderByDescending(e => e.rated).ToList();
                }
                return sortedMovieList;
            }
            return null;
        }

        public List<IMovie> RemoveDuplicates(List<IMovie> movies, List<IMovie> moreMovies)
        {
            if (movies.Count > 0 && moreMovies.Count > 0)
            {
                return movies.Concat(moreMovies).Distinct(_movieComparer).ToList();
            }
            return null;
        }

        public List<string> CreateTitlesList(List<IMovie> movies)
        {
            if (movies.Count > 0)
            {
                return movies.Select(m => m.title).ToList();
            }
            return null;
        }
    }
}
