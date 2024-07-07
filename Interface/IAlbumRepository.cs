using MusicGallery.Models;

namespace MusicGallery.Interface
{
    public interface IAlbumRepository
    {

        Task<List<Album>> GetAllAlbums();
        Task<List<Album>> GetAllAlbumsByArtist(int artistId);
        Task<Album?> GetAlbum(int id);
        Task CreateAlbum(Album album);
        Task UpdateAlbum(Album album);
        Task DeleteAlbum(Album album);
    }
}