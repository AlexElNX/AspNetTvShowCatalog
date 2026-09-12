using Microsoft.AspNetCore.Mvc;
using TVShowCatalog.Models;
using TVShowCatalog.Services.Interfaces;

namespace TVShowCatalog.Controllers
{
    public class TvShowController : Controller
    {
        private readonly ITvShowService _tvShowService;

        public TvShowController(ITvShowService tvShowService)
        {
            _tvShowService = tvShowService;
        }

        // GET: TvShows
        public async Task<IActionResult> Index()
        {
            var shows = await _tvShowService.GetAllAsync();
            return View(shows);
        }


        // GET: TvShows/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tvShow = await _tvShowService.GetByIdAsync(id.Value);

            if (tvShow == null) return NotFound();

            return View(tvShow);
        }

        // GET: TvShows/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: TvShows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Showrunner,Genre,Premiere,Poster,Description")] TvShow tvShow, IFormFile? posterFile)
        {
            if (ModelState.IsValid)
            {
                await _tvShowService.CreateAsync(tvShow, posterFile);
                return RedirectToAction(nameof(Index));
            }
            return View(tvShow);
        }


        // GET: TvShows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tvShow = await _tvShowService.GetByIdAsync(id.Value);

            if (tvShow == null) return NotFound();

            return View(tvShow);
        }


        // POST: TvShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Showrunner,Genre,Premiere,Poster,Description")] TvShow tvShow, IFormFile? posterFile)
        {
            if (id != tvShow.Id) return NotFound();

            if (ModelState.IsValid)
            {
                bool success = await _tvShowService.UpdateAsync(tvShow, posterFile);
                if (!success) return NotFound();


                return RedirectToAction(nameof(Index));
            }

            return View(tvShow);
        }


        // GET: TvShows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tvShow = await _tvShowService.GetByIdAsync(id.Value);
            
            if (tvShow == null) return NotFound();

            return View(tvShow);
        }

        // POST: TvShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _tvShowService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
