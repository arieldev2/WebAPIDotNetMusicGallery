using MusicGallery.Models;

namespace MusicGallery.Service{
    public interface IAlbumService{

        Task<List<Album>> GetAllAlbums();
        Task<List<Album>> GetAllAlbumsByArtist(int artistId);
        Task<Album?> GetAlbum(int id);
        Task CreateAlbum(Album album);
        Task UpdateAlbum(Album album);
        Task DeleteAlbum(Album album);
    }
}