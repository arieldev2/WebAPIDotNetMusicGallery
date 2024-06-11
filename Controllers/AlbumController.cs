using Microsoft.AspNetCore.Mvc;
using MusicGallery.DTOs;
using MusicGallery.Models;
using MusicGallery.Response;
using MusicGallery.Service;

namespace MusicGallery.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {

        private readonly IAlbumService _albumService;


        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Album>>> GetAllAlbums()
        {
            return Ok(await _albumService.GetAllAlbums());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Album>>> GetAllAlbumsByArtist(int id)
        {
            return Ok(await _albumService.GetAllAlbumsByArtist(id));
        }

        [HttpGet("detail/{id}")]
        public async Task<ActionResult<Album>> GetSingleAlbum(int id)
        {
            return Ok(await _albumService.GetAlbum(id));
        }

        [HttpPost]
        public async Task<ActionResult<Album>> CreateAlbum([FromBody] AlbumDTO albumDTO)
        {

            try
            {
                var newAlbum = new Album
                {
                    Title = albumDTO.Title,
                    NumOfSongs = albumDTO.NumOfSongs,
                    PublishedDate = albumDTO.PublishedDate,
                    ArtistId = albumDTO.ArtistId,
                };
                await _albumService.CreateAlbum(newAlbum);
                return Ok(newAlbum);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Album>> UpdateAlbum(int id, AlbumUpdateDTO albumUpdateDTO)
        {

            try
            {
                var albumExists = await _albumService.GetAlbum(id);
                if (albumExists == null)
                {
                    return BadRequest("Album don't exists");
                }
                albumExists.Title = albumUpdateDTO.Title;
                albumExists.PublishedDate = albumUpdateDTO.PublishedDate;
                albumExists.NumOfSongs = albumUpdateDTO.NumOfSongs;
                await _albumService.UpdateAlbum(albumExists);
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

            var albumExists = await _albumService.GetAlbum(id);
            if (albumExists == null)
            {
                return BadRequest("Album don't exists");
            }
            await _albumService.DeleteAlbum(albumExists);
            return Ok(new MGResponse
            {
                Message = "Deleted"
            });

        }


    }
}