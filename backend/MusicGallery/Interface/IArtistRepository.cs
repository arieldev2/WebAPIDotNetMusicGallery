using MusicGallery.Models;

namespace MusicGallery.Interface
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetArtists();
        Task<Artist?> GetArtist(int id);
        Task CreateArtist(Artist artist);
        Task UpdateArtist(Artist artist);
        Task DeleteArtist(Artist artist);

    }
}