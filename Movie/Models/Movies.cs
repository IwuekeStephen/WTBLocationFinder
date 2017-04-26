using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Movies:IMovie
    {

        private static string baseUrl = "http://www.omdbapi.com/";
        public IEnumerable<MovieViewModel> GetAllMovies()
        {
            string title = string.Empty;
              IEnumerable<MovieViewModel> movie  = GetAllTheMovies(title);
            
            return movie;

        }

        public IEnumerable<MovieViewModel> GetMoviesByTitle(string title)
        {
            IEnumerable<MovieViewModel> movie = GetAllTheMovies(title);
            return movie;
        }
        private  IEnumerable<MovieViewModel> GetAllTheMovies(string title)
        {

            //string movieUrl = baseUrl + "?t=" +title + "&Y=1983&r=json";
            string movieUrl = "https://api.foursquare.com/v2/venues/search?ll=40.7,-74&client_id=5BYGVYUZCE2LX52TUPT4WN05NGKDRX0DV3B1YMUHUEVAONIK&client_secret=2KVUD2ACFBPCZFRGYGXELQF0D0P45GMUCUV4EWVNET1GQBOD&v=20170101";
                WebClient wclient = new WebClient();
                byte[] data = wclient.DownloadData(movieUrl);
                Stream stream = new MemoryStream(data);
                StreamReader reader = new StreamReader(stream);
                string result = "[" + reader.ReadToEnd() + "]";
                var movie = JsonConvert.DeserializeObject<IEnumerable<MovieViewModel>>(result);
            return movie;


        }
       
    }
}