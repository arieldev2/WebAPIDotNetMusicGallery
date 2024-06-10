using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicGallery.DTOs;
using MusicGallery.Models;
using MusicGallery.Response;

namespace MusicGallery.Service{
    public class ArtistService : IArtistService
    {
        private readonly MusicGalleryDBContext _context;

        public ArtistService(MusicGalleryDBContext context){
            _context = context;
        }

        public async Task CreateArtist(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtist(Artist artist)
        {
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
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