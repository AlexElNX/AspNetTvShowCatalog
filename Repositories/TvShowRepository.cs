using Microsoft.EntityFrameworkCore;
using TVShowCatalog.Interfaces;
using TVShowCatalog.Models;

namespace TVShowCatalog.Repositories
{
    public class TvShowRepository : IRepository<TvShow>
    {
        private readonly TvShowContext _context;
        public TvShowRepository(TvShowContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<TvShow>> GetAllAsync()
        {
            return await _context.TvShows.ToListAsync();
        }

        public async Task<TvShow?> GetByIdAsync(int id)
        {
            return await _context.TvShows.FindAsync(id);
        }

        public async Task CreateAsync(TvShow tvShow)
        {
            await _context.AddAsync(tvShow);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TvShow tvShow)
        {
            _context.Update(tvShow);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tvShow = await _context.TvShows.FindAsync(id);
            if (tvShow != null)
            {
                _context.TvShows.Remove(tvShow);
                await _context.SaveChangesAsync();
            }
        }
    }
}