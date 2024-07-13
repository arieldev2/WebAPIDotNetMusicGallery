using Microsoft.EntityFrameworkCore;
using MusicGallery.Interface;
using MusicGallery.Models;

namespace MusicGallery.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly MusicGalleryDBContext _context;

        public ArtistRepository(MusicGalleryDBContext context)
        {
            _context = context;
        }

        public async Task CreateArtist(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtist(Artist artist)
        {
            var request = _context.Artists.Include(item => item.Albums).Where(item => item.Id == artist.Id).SingleOrDefault();
            if (request != null)
            {
                _context.Artists.Remove(request);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Artist?> GetArtist(int id)
        {
            return await _context.Artists.FindAsync(id);
        }

        public async Task<List<Artist>> GetArtists()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task UpdateArtist(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();

        }
    }
}