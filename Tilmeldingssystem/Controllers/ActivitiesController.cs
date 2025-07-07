using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;
using Tilmeldingssystem.Models.Dto;
using Tilmeldingssystem.Services;

namespace Tilmeldingssystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;
        private readonly IActivityService _activityService;

        public ActivitiesController(IActivityRepository activityRepository, IActivityService activityService)
        {
            _activityRepository = activityRepository;
            _activityService = activityService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Activity>> GetAllActivities()
        {
            var activities = _activityRepository.GetAllActivities();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public ActionResult<Activity> GetActivityById(int id)
        {
            var activity = _activityRepository.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPost]
        public ActionResult AddActivity([FromBody] CreateActivityDto activityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // <-- this will show you what is failing
            }

            if (activityDto == null)
                return BadRequest();

            var activity = new Activity
            {
                Name = activityDto.Name,
                Description = activityDto.Description,
                StartTime = activityDto.StartTime,
                EndTime = activityDto.EndTime,
                Location = activityDto.Location,
                Price = activityDto.Price
            };

            _activityRepository.AddActivity(activity);

            if (_activityRepository.SaveChanges())
            {
                return CreatedAtAction(nameof(GetActivityById), new { id = activity.ActivityId }, activity);
            }

            return BadRequest("Could not save activity.");
        }



        [HttpPut("{id}")]
        public ActionResult UpdateActivity(int id, Activity activity)
        {
            if (id != activity.ActivityId)
            {
                return BadRequest();
            }
            _activityRepository.UpdateActivity(activity);
            if (_activityRepository.SaveChanges())
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteActivity(int id)
        {
            var activity = _activityRepository.GetActivityById(id);
            if (activity == null)
            {
                return NotFound();
            }
            _activityRepository.DeleteActivity(id);
            if (_activityRepository.SaveChanges())
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPost("register")]
        public async Task<ActionResult<MemberActivityRegistrationResultDto>> RegisterMemberToActivity(MemberActivityRegistrationDto dto)
        {
            var result = await _activityService.RegisterMemberToActivityAsync(dto);

            if (result == null)
                return BadRequest("Registration failed: member or activity not found, or member already registered.");

            return Ok(result);
        }
    }
}
