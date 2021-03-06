using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieLibrary;
using MovieLibrary.Controllers;
using MovieLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace UnitTests
{
    [TestClass]
    public class MovieLibraryTest
    {
        private readonly IMovieHandler _movieHandler;
        private readonly MovieController _movieController;
        private readonly SampleData _sampleData;

        public MovieLibraryTest()
        {
            _movieHandler = new MovieHandler(new MovieComparer());
            _movieController = new MovieController(_movieHandler);
            _sampleData = new SampleData();
        }

        [TestMethod]
        public void CreateTitlesList_EmptyList_ReturnsNull()
        {
            Assert.IsNull(_movieHandler.CreateTitlesList(new List<IMovie>()));
        }

        [TestMethod]
        public void CreateTitlesList_ListOfMovies_ReturnsListOfStrings()
        {
            var expected = _sampleData.GetTitles();
            var actual = _movieHandler.CreateTitlesList(_sampleData.GetMovies());
            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Toplist_Returns_100MovieTitles()
        //{
        //    var controller = new MovieLibrary.Controllers.MovieController();
        //    var expectedCount = 100;
        //    var actualCount = controller.Toplist().Count();
        //    Assert.AreEqual(expectedCount, actualCount);
        //}

        //[TestMethod]
        //[DataRow(true)]
        //[DataRow(false)]
        //public void Toplist_ReturnsTop100MoviesCorrectOrder()
        //{
        //    var controller = new MovieController(new MovieHandler(new I));

        //    HttpClient client = new HttpClient();
        //    var result = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
        //    var movieList = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());
        //    var sortedMovieList = movieList.OrderBy(m => m.rated).ToList();

        //    //for (int i = 1; i < sortedMovieList.Count; i++)
        //    //{
        //    //    Movie a = sortedMovieList[i - 1];
        //    //    Movie b = sortedMovieList[i];
        //    //    Assert.IsTrue(Convert.ToDouble(a.rated) <= Convert.ToDouble(b.rated));
        //    //}

        //    var sortedTitlesList = new List<string>();
        //    foreach (var movie in sortedMovieList)
        //    {
        //        sortedTitlesList.Add(movie.title);
        //    }

        //    var movieListFromController = controller.Toplist();
        //    for (int i = 0; i < sortedTitlesList.Count; i++)
        //    {
        //        Assert.AreEqual(movieListFromController.ElementAt(i), sortedTitlesList[i]);
        //    }

        //}

        //[TestMethod]
        //[DataRow("tt0111161", "The Shawshank Redemption")]
        //public void GetMovieById_ReturnsCorrectMovie(string id, string expectedTitle)
        //{
        //    var controller = new MovieLibrary.Controllers.MovieController();
        //    var actualTitle = controller.GetMovieById(id).title;

        //    Assert.AreEqual(expectedTitle, actualTitle);
        //}


    }
}
