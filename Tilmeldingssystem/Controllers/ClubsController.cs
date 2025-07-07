using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;
using Tilmeldingssystem.Models.Dto;
using Tilmeldingssystem.Services;

namespace Tilmeldingssystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubRepository _clubRepository;
        private readonly IMemberService _memberService;


        public ClubsController(IClubRepository clubRepository, IMemberService memberService)
        {
            _clubRepository = clubRepository;
            _memberService = memberService;
        }

        // GET: api/clubs
        [HttpGet]
        public ActionResult<IEnumerable<ClubDto>> GetAllClubs()
        {
            var clubs = _clubRepository.GetAllClubs()
                .Select(c => new ClubDto
                {
                    ClubId = c.ClubId,
                    Name = c.Name,
                    Location = c.Location,
                    Description = c.Description
                })
                .ToList();

            return Ok(clubs);
        }

        // GET: api/clubs/with-members
        [HttpGet("with-members")]
        public ActionResult<IEnumerable<ClubWithMembersDto>> GetAllClubsWithMembers()
        {
            var clubs = _clubRepository.GetAllClubsWithMembers()
                .Select(c => new ClubWithMembersDto
                {
                    ClubId = c.ClubId,
                    Name = c.Name,
                    Location = c.Location,
                    Description = c.Description,
                    MemberNames = c.MemberClubs
                        .Select(mc => mc.Member.FullName)
                        .ToList()
                })
                .ToList();

            return Ok(clubs);
        }

        // GET: api/clubs/{id}
        [HttpGet("{id}")]
        public ActionResult<ClubDto> GetClubById(int id)
        {
            var club = _clubRepository.GetClubById(id);
            if (club == null)
                return NotFound();

            var dto = new ClubDto
            {
                Name = club.Name,
                Location = club.Location,
                Description = club.Description
            };

            return Ok(dto);
        }

        // POST: api/clubs
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

        // PUT: api/clubs/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateClub(int id, Club club)
        {
            if (id != club.ClubId)
                return BadRequest();

            _clubRepository.UpdateClub(club);
            if (_clubRepository.SaveChanges())
                return NoContent();

            return NotFound();
        }

        [HttpPost("register-member")]
        public async Task<IActionResult> RegisterMemberToClub([FromBody] MemberClubRegistrationDto dto)
        {
            if (dto == null || dto.MemberId <= 0 || dto.ClubId <= 0)
                return BadRequest("Invalid input.");

            var result = await _memberService.RegisterMemberToClubAsync(dto);

            if (result.Contains("not found"))
                return NotFound(result);

            if (result.Contains("already"))
                return BadRequest(result);

            return Ok(result);
        }


    }
}
