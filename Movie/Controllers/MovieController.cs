using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;


    
namespace Movie.Controllers
{
    public class MovieController : Controller
    {
        private IMovie _movieRepository;

        public MovieController()
          {
            _movieRepository = new Movies();
        }

        public MovieController(IMovie movie)
        {
            _movieRepository = movie;
        }
        // GET: Movie
        public ActionResult Index()
        {
            IEnumerable<MovieViewModel> mvm = _movieRepository.GetAllMovies();

            return View(mvm);
        }

        // GET: Movie/Details/5
        public ActionResult Search(FormCollection formc)
        {
            string title = formc["txtSearch"];
            IEnumerable<MovieViewModel> mvm = _movieRepository.GetMoviesByTitle(title);
            return View("Index", mvm);
        }

        [ChildActionOnly]
        public ActionResult PopUp()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
