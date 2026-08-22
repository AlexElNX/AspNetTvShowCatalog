using Microsoft.AspNetCore.Mvc;
using TVShowCatalog.Models;

namespace TVShowCatalog.Controllers
{
    public class TvShowController : Controller
    {
        public TvShowContext db;
        public TvShowController(TvShowContext context) 
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<TvShow> tvShows = await Task.Run(() => db.TvShows);
            return View(tvShows);
        }
    }
}
