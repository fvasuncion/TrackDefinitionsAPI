using Microsoft.AspNetCore.Mvc;
using TrackDefinitionsAPI.Models;
using TrackDefinitionsAPI.Services;

namespace TrackDefinitionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        //this is a sample to make it conflict
        private readonly ITrackDefinitionService _trackService;

        public TrackController(ITrackDefinitionService trackService)
        {
            _trackService = trackService;
        }

        [HttpPost("process")]
        public ActionResult<List<DepartmentModel>> ProcessTrack(TrackDefinitionModel track)
        {
            var result = _trackService.ProcessTrack(track);
            return Ok(result);
        }
    }
}
