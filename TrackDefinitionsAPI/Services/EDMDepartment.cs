using TrackDefinitionsAPI.RequestModels;

namespace TrackDefinitionsAPI.Services
{
    public class EDMDepartment : IDepartment
    {
        public TrackDefinitionResult ProcessTrack(TrackDefinition track)
        {
            // EDM processing logic
            double predictedProfit = (track.StreamCount * 0.01) - track.Advance;

            TrackDefinitionResult trackResult = new TrackDefinitionResult();
            trackResult.Department = "EDM";
            trackResult.PredictedProfit = predictedProfit;
            trackResult.ApprovalRequired = predictedProfit < 1000;

            return trackResult;
        }
    }
}
