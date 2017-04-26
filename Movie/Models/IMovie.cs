using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Models
{
   public interface IMovie
    {
        IEnumerable<MovieViewModel> GetAllMovies();
        IEnumerable<MovieViewModel> GetMoviesByTitle(string title);
    }
}
