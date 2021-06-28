using MovieApp.Client.Helpers;
using MovieApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/movies";

        public MoviesRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<int> AddMovie(Movie movie)
        {
            var response = await httpService.Post<Movie, int>(url, movie);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task UpdateMovie(Movie movie)
        {
            var response = await httpService.Put(url, movie);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeleteMovie(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<Movie> GetMovie(int id)
        {
            return (await httpService.Get<Movie>($"{url}/{id}")).Response;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return (await httpService.Get<List<Movie>>(url)).Response;
        }
    }
}
