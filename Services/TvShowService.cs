using Microsoft.EntityFrameworkCore;
using TVShowCatalog.Models;
using TVShowCatalog.Services.Interfaces;

namespace TVShowCatalog.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly TvShowContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TvShowService(TvShowContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<TvShow>> GetAllAsync()
        {
            return await _context.TvShows.ToListAsync();
        }

        public async Task<TvShow?> GetByIdAsync(int id)
        {
            return await _context.TvShows.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateAsync(TvShow tvShow, IFormFile? posterFile)
        {
            if (posterFile != null && posterFile.Length > 0)
            {
                tvShow.Poster = await SavePosterAsync(posterFile);
            }

            _context.Add(tvShow);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(TvShow tvShow, IFormFile? posterFile)
        {
            if (posterFile != null && posterFile.Length > 0)
            {
                tvShow.Poster = await SavePosterAsync(posterFile);
            }

            try
            {
                _context.Update(tvShow);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.TvShows.AnyAsync(e => e.Id == tvShow.Id))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tvShow = await _context.TvShows.FindAsync(id);
            if (tvShow == null) return false;

            if (!string.IsNullOrEmpty(tvShow.Poster))
            {
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, tvShow.Poster.TrimStart('/'));
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }

            _context.TvShows.Remove(tvShow);
            await _context.SaveChangesAsync();
            return true;
        }


        private async Task<string> SavePosterAsync(IFormFile posterFile)
        {
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            Directory.CreateDirectory(uploadsFolder);

            string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(posterFile.FileName);
            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await posterFile.CopyToAsync(stream);
            }

            return "/images/" + fileName;
        }
    }
}