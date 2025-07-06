using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationsController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Registration>> GetAllRegistrations()
        {
            var registrations = _registrationRepository.GetAllRegistrations();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public ActionResult<Registration> GetRegistrationById(int id)
        {
            var registration = _registrationRepository.GetRegistrationById(id);
            if (registration == null)
            {
                return NotFound();
            }
            return Ok(registration);
        }

        [HttpPost]
        public ActionResult AddRegistration(Registration registration)
        {
            _registrationRepository.AddRegistration(registration);
            if (_registrationRepository.SaveChanges())
            {
                return CreatedAtAction(nameof(GetRegistrationById), new { id = registration.RegistrationId }, registration);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRegistration(int id, Registration registration)
        {
            if (id != registration.RegistrationId)
            {
                return BadRequest();
            }
            _registrationRepository.UpdateRegistration(registration);
            if (_registrationRepository.SaveChanges())
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
