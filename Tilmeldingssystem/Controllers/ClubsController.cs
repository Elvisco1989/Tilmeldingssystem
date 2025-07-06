using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubRepository _clubRepository;

        public ClubsController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Club>> GetAllClubs()
        {
            var clubs = _clubRepository.GetAllClubs();
            return Ok(clubs);
        }

        [HttpGet("{id}")]
        public ActionResult<Club> GetClubById(int id)
        {
            var club = _clubRepository.GetClubById(id);
            if (club == null)
            {
                return NotFound();
            }
            return Ok(club);
        }

        [HttpPost]
        public ActionResult AddClub(Club club)
        {
            _clubRepository.AddClub(club);
            if (_clubRepository.SaveChanges())
            {
                return CreatedAtAction(nameof(GetClubById), new { id = club.ClubId }, club);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateClub(int id, Club club)
        {
            if (id != club.ClubId)
            {
                return BadRequest();
            }
            _clubRepository.UpdateClub(club);
            if (_clubRepository.SaveChanges())
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
