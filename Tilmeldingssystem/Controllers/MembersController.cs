using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetAllMembers()
        {
            var members = _memberRepository.GetAllMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public ActionResult<Member> GetMemberById(int id)
        {
            var member = _memberRepository.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        public ActionResult AddMember(Member member)
        {
            _memberRepository.AddMember(member);
            if (_memberRepository.SaveChanges())
            {
                return CreatedAtAction(nameof(GetMemberById), new { id = member.MemberId }, member);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMember(int id, Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest();
            }
            _memberRepository.UpdateMember(member);
            if (_memberRepository.SaveChanges())
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMember(int id)
        {
            _memberRepository.DeleteMember(id);
            if (_memberRepository.SaveChanges())
            {
                return NoContent();
            }
            return NotFound();
        }   
    }
}
