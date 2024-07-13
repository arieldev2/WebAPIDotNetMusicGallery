using Microsoft.EntityFrameworkCore;
using MusicGallery.Interface;
using MusicGallery.Models;

namespace MusicGallery.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicGalleryDBContext _context;

        public AlbumRepository(MusicGalleryDBContext context)
        {
            _context = context;
        }

        public async Task CreateAlbum(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlbum(Album album)
        {
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }

        public async Task<Album?> GetAlbum(int id)
        {
            return await _context.Albums.FindAsync(id);
        }

        public async Task<List<Album>> GetAllAlbums()
        {
            var albums = await _context.Albums.ToListAsync();
            return albums;
        }

        public async Task<List<Album>> GetAllAlbumsByArtist(int artistId)
        {
            var albums = _context.Albums.Where(x => x.ArtistId == artistId);
            return await albums.ToListAsync();
        }

        public async Task UpdateAlbum(Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }
    }
}