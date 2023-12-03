using TrackDefinitionsAPI.RequestModels;

namespace TrackDefinitionsAPI.Services
{
    public interface IDepartment
    {
        TrackDefinitionResult ProcessTrack(TrackDefinition track);
    }
}
