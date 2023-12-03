using Microsoft.AspNetCore.Mvc;
using TrackDefinitionsAPI.Models;
using TrackDefinitionsAPI.RequestModels;
using TrackDefinitionsAPI.Services;

namespace TrackDefinitionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        //private readonly ITrackDefinitionService _trackService;

        //public TrackController(ITrackDefinitionService trackService)
        //{
        //    _trackService = trackService;
        //}

        //[HttpPost("process")]
        //public ActionResult<List<DepartmentModel>> ProcessTrack(TrackDefinitionModel track)
        //{
        //    var result = _trackService.ProcessTrack(track);
        //    return Ok(result);
        //}

        private readonly IEnumerable<IDepartment> _departments;
        private readonly ITagMappingService _tagMappingService;

        public TrackController(IEnumerable<IDepartment> departments, ITagMappingService tagMappingService)
        {
            _departments = departments;
            _tagMappingService = tagMappingService;
        }

        [HttpPost("process")]
        public ActionResult<List<TrackDefinitionResult>> ProcessTrack(TrackDefinition track)
        {
            List<TrackDefinitionResult> result = new List<TrackDefinitionResult>();     

            foreach (var department in _departments)
            {
                var departmentTags = _tagMappingService.GetDepartmentType(department.GetType().Name);

                foreach (var tag in track.Tags)
                {
                    result.Add(department.ProcessTrack(track));
                }
            }
            return Ok(result);        
        }
    }
}
