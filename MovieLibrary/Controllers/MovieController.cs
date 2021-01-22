using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;

namespace MovieLibrary.Controllers
{
    

    [ApiController]
    [Route("[controller]")]
    public class MovieController
    {
        static HttpClient client = new HttpClient();

        [HttpGet]
        [Route("/toplist")]
        public IEnumerable<string> Toplist(bool ascending = true)
        {
            var firstResult = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            var unsortedMovieList = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(firstResult.Content.ReadAsStream()).ReadToEnd());
            var detailedMoviesResult = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json").Result;
            var unsortedDetailedMovieList = JsonSerializer.Deserialize<List<DetailedMovie>>(new StreamReader(firstResult.Content.ReadAsStream()).ReadToEnd());

            //var combinedLists = CombineLists(TitlesInOrderBasedOnRating(ascending, unsortedMovieList, unsortedDetailedMovieList);

            return null;
            //return TitlesInOrderBasedOnRating(ascending, unsortedMovieList);
        }

        private static List<string> TitlesInOrderBasedOnRating(bool ascending, List<Movie> movieList)
        {
            List<Movie> sortedMovieList = new List<Movie>();
            List<string> sortedTitlesList = new List<string>();
            foreach (var move in movieList)
            {

            }
            if (ascending)
            {
                //sortedMovieList = unsortedDetailedMovieList.OrderBy(e => e.rated).ToList();
            }
            else
            {
                sortedMovieList = sortedMovieList.OrderByDescending(e => e.rated).ToList();
            }
            foreach (var m in sortedMovieList)
            {
                sortedTitlesList.Add(m.title);
            }
            return sortedTitlesList;
        }

        private static List<IMovie> RemoveDuplicates(List<IMovie> movies, List<IMovie> detailedMovies)
        {
            return movies.Concat(detailedMovies).Distinct(new MovieComparer()).ToList();
        }

        //private List<IMovie> CombineLists(List<IMovie> movies, List<IMovie> detailedMovies)
        //{

        //}

        [HttpGet]
        [Route("/movie")]
        public Movie GetMovieById(string id) {
            var result = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            var movieList = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());
            foreach (var movie in movieList) {
                if (movie.id.Equals(id))
                {
                    return movie;
                }
            }
            return null;
        }

        //[HttpGet]
        //[Route("/detailedMovies")]
        //public IEnumerable<string> GetDetailedMovies(bool ascending = true)
        //{
        //    var result = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json").Result;
        //    var unsortedMovieList = JsonSerializer.Deserialize<List<DetailedMovie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());
        //    return TitlesInOrderBasedOnRating(ascending, unsortedMovieList);
        //}
    }
}