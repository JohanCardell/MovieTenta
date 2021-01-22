using MovieLibrary.Models;
using System.Collections.Generic;

namespace MovieLibrary
{
    public interface IMovieComparer : IEqualityComparer<IMovie>
    {
        bool Equals(IMovie a, IMovie b);
        int GetHashCode(IMovie m);
    }
}