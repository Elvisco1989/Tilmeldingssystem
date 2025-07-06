using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityRepository _activityRepository;

        public ActivitiesController(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
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
        public ActionResult AddActivity(Activity activity)
        {
            _activityRepository.AddActivity(activity);
            if (_activityRepository.SaveChanges())
            {
                return CreatedAtAction(nameof(GetActivityById), new { id = activity.ActivityId }, activity);
            }
            return BadRequest();
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
    }
}
