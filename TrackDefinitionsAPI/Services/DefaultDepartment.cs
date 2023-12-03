using TrackDefinitionsAPI.RequestModels;

namespace TrackDefinitionsAPI.Services
{
    public class DefaultDepartment : IDepartment
    {
        public TrackDefinitionResult ProcessTrack(TrackDefinition track)
        {
            double predictedProfit = (track.StreamCount * 0.008) - track.Advance;

            TrackDefinitionResult trackResult = new TrackDefinitionResult();
            trackResult.Department = "Default";
            trackResult.PredictedProfit = predictedProfit;
            trackResult.ApprovalRequired = predictedProfit < 1100;

            return trackResult;
        }
    }
}
