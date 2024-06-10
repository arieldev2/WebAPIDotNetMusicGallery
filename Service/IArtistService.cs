using Microsoft.AspNetCore.Mvc;
using MusicGallery.DTOs;
using MusicGallery.Models;
using MusicGallery.Response;

namespace MusicGallery.Service{
    public interface IArtistService{
        Task<List<Artist>> GetArtists();
        Task<Artist?> GetArtist(int id);
        Task CreateArtist(Artist artist);
        Task UpdateArtist(Artist artist);
        Task DeleteArtist(Artist artist );

    }
}