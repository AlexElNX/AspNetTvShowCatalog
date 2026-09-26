using Microsoft.EntityFrameworkCore;
using TVShowCatalog.Models;
using TVShowCatalog.Interfaces;

namespace TVShowCatalog.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly IRepository<TvShow> _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TvShowService(IRepository<TvShow> repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<TvShow>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TvShow?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateAsync(TvShow tvShow, IFormFile? posterFile)
        {
            if (posterFile != null && posterFile.Length > 0)
            {
                tvShow.Poster = await SavePosterAsync(posterFile);
            }

            await _repository.CreateAsync(tvShow);
        }

        public async Task<bool> UpdateAsync(TvShow tvShow, IFormFile? posterFile)
        {
            var existingShow = _repository.GetByIdAsync(tvShow.Id);
            if(existingShow == null) return false;

            if (posterFile != null && posterFile.Length > 0)
            {
                tvShow.Poster = await SavePosterAsync(posterFile);
            }

            await _repository.UpdateAsync(tvShow);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tvShow = await _repository.GetByIdAsync(id);
            if (tvShow == null) return false;

            if (!string.IsNullOrEmpty(tvShow.Poster))
            {
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, tvShow.Poster.TrimStart('/'));
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }

            await _repository.DeleteAsync(id);
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