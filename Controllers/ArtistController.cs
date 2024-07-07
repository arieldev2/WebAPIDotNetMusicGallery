using Microsoft.AspNetCore.Mvc;
using MusicGallery.DTOs;
using MusicGallery.Models;
using MusicGallery.Response;
using MusicGallery.Interface;

namespace MusicGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        private readonly IArtistRepository _artistRepository;

        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Artist>>> GetArtists()
        {
            var artists = await _artistRepository.GetArtists();
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _artistRepository.GetArtist(id);
            return Ok(artist);
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> CreateArtist([FromBody] ArtistDTO artist)
        {

            try
            {
                if (artist.Name == string.Empty || artist.Genre == string.Empty)
                {
                    return BadRequest("Name and Genre are required");
                }
                var newArtist = new Artist()
                {
                    Name = artist.Name,
                    Genre = artist.Genre
                };
                await _artistRepository.CreateArtist(newArtist);
                return Ok(newArtist);
            }
            catch
            {
                return BadRequest("Something went wrong");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Artist>> UpdateArtist(int id, ArtistDTO artist)
        {

            try
            {
                if (artist.Name == string.Empty || artist.Genre == string.Empty)
                {
                    return BadRequest("Name and Genre are required");
                }

                var artistExists = await _artistRepository.GetArtist(id);
                if (artistExists == null)
                {
                    return BadRequest("Artist don't exists");
                }
                artistExists.Name = artist.Name;
                artistExists.Genre = artist.Genre;

                await _artistRepository.UpdateArtist(artistExists);
                return Ok(artistExists);
            }
            catch
            {
                return BadRequest("Something went wrong");

            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MGResponse>> DeleteArtist(int id)
        {
            var artistExists = await _artistRepository.GetArtist(id);
            if (artistExists == null)
            {
                return BadRequest("Artist don't exists");
            }
            await _artistRepository.DeleteArtist(artistExists);
            return Ok(new MGResponse
            {
                Message = "Deleted"
            });
        }

    }
}