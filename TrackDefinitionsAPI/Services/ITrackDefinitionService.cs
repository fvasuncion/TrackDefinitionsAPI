using TrackDefinitionsAPI.Models;

namespace TrackDefinitionsAPI.Services
{
    public interface ITrackDefinitionService
    {
        List<DepartmentModel> ProcessTrack(TrackDefinitionModel track);
    }
}
