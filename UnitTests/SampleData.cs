using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class SampleData
    {
        public List<IMovie> GetMovies() {
            return new List<IMovie> {
                new Movie { id = "1", title = "Bad taste", rated = "8.2" },
                new Movie { id = "2", title = "Brain dead", rated = "9.0" },
                new Movie { id = "3", title = "Night of the living dead", rated = "7.5" },
            };
        }

        public List<string> GetTitles() {
            return new List<string> { "Bad taste", "Brain dead", "Night of the living dead" };
        }
    }
}
