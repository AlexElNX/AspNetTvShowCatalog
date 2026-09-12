using TVShowCatalog.Models;

namespace TVShowCatalog.Services.Interfaces
{
    public interface ITvShowService
    {
        Task<IEnumerable<TvShow>> GetAllAsync();
        Task<TvShow?> GetByIdAsync(int id);
        Task CreateAsync(TvShow tvShow, IFormFile? posterFile);
        Task<bool> UpdateAsync(TvShow tvShow, IFormFile? posterFile);
        Task<bool> DeleteAsync(int id);
    }
}