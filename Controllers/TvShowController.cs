using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TVShowCatalog.Models;

namespace TVShowCatalog.Controllers
{
    public class TvShowController : Controller
    {
        private readonly TvShowContext _context;
        public TvShowController(TvShowContext context)
        {
            _context = context;
        }

        // GET: TvShows
        public async Task<IActionResult> Index()
        {
            return View(await _context.TvShows.ToListAsync());
        }


        // GET: TvShows/Details

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var tvShow = await _context.TvShows
                .FirstOrDefaultAsync(m => m.Id == id);

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
        public async Task<IActionResult> Create([Bind("Id,Title,Showrunner,Genre,Premiere,Poster,Description")] TvShow tvShow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvShow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvShow);
        }


        // GET: TvShows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var tvShow = await _context.TvShows.FindAsync(id);

            if (tvShow == null) return NotFound();

            return View(tvShow);
        }


        // POST: TvShows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Showrunner,Genre,Premiere,Poster,Description")] TvShow tvShow)
        {
            if (id != tvShow.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvShow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!TvShowExists(tvShow.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(tvShow);
        }


        // GET: TvShows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var tvShow = await _context.TvShows
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (tvShow == null) return NotFound();

            return View(tvShow);
        }

        // POST: TvShows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tvShow = await _context.TvShows.FindAsync(id);
            if(tvShow != null)
            {
                _context.TvShows.Remove(tvShow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvShowExists(int id)
        {
            return _context.TvShows.Any(tv => tv.Id == id);
        }
    }
}
