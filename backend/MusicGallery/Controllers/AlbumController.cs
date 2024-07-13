using Microsoft.AspNetCore.Mvc;
using MusicGallery.ViewModels;
using MusicGallery.Models;
using MusicGallery.Response;
using MusicGallery.Interface;

namespace MusicGallery.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {

        private readonly IAlbumRepository _albumRepository;


        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Album>>> GetAllAlbums()
        {
            return Ok(await _albumRepository.GetAllAlbums());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Album>>> GetAllAlbumsByArtist(int id)
        {
            return Ok(await _albumRepository.GetAllAlbumsByArtist(id));
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<Album>> GetSingleAlbum(int id)
        {
            return Ok(await _albumRepository.GetAlbum(id));
        }

        [HttpPost]
        public async Task<ActionResult<Album>> CreateAlbum([FromBody] AlbumViewModel albumViewModel)
        {

            try
            {
                var newAlbum = new Album
                {
                    Title = albumViewModel.Title,
                    NumOfSongs = albumViewModel.NumOfSongs,
                    PublishedDate = albumViewModel.PublishedDate,
                    ArtistId = albumViewModel.ArtistId,
                };
                await _albumRepository.CreateAlbum(newAlbum);
                return Ok(newAlbum);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Album>> UpdateAlbum(int id, AlbumUpdateViewModel albumUpdateViewModel)
        {

            try
            {
                var albumExists = await _albumRepository.GetAlbum(id);
                if (albumExists == null)
                {
                    return BadRequest("Album don't exists");
                }
                albumExists.Title = albumUpdateViewModel.Title;
                albumExists.PublishedDate = albumUpdateViewModel.PublishedDate;
                albumExists.NumOfSongs = albumUpdateViewModel.NumOfSongs;
                await _albumRepository.UpdateAlbum(albumExists);
                return Ok(albumExists);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MGResponse>> DeleteAlbum(int id)
        {

            var albumExists = await _albumRepository.GetAlbum(id);
            if (albumExists == null)
            {
                return BadRequest("Album don't exists");
            }
            await _albumRepository.DeleteAlbum(albumExists);
            return Ok(new MGResponse
            {
                Message = "Deleted"
            });

        }


    }
}