using MovieLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary
{
    public class MovieComparer : IEqualityComparer<IMovie>
    {
        public bool Equals(IMovie a, IMovie b)
        {
            return a.id == b.id;
           
        }
        public int GetHashCode(IMovie m)
        {
            return int.Parse( m.id);
        }
    }
}
