using TrackDefinitionsAPI.Models;

namespace TrackDefinitionsAPI.Services
{
    public class TrackDefinitionService : ITrackDefinitionService
    {
        public List<DepartmentModel> ProcessTrack(TrackDefinitionModel track)
        {
            List<DepartmentModel> results = new List<DepartmentModel>();
            List<string> definedTags = new List<string> { "techno", "club", "deep", "trance" , "acid" };

            if (track.Tags.Contains("techno") || track.Tags.Contains("club") || track.Tags.Contains("deep"))
            {
                decimal predictedProfit = (track.StreamCount * 0.01m) - track.Advance;
                results.Add(new DepartmentModel
                {
                    Department = "EDM",
                    PredictedProfit = predictedProfit,
                    ApprovalRequired = predictedProfit < 1000 //threshold
                });
            }

            if (track.Tags.Contains("trance"))
            {
                decimal predictedProfit = ((track.StreamCount * 0.015m) - track.Advance) * 0.9m;
                results.Add(new DepartmentModel
                {
                    Department = "Trance",
                    PredictedProfit = predictedProfit,
                    ApprovalRequired = predictedProfit < 800 //threshold
                });
            }

            if (track.Tags.Contains("acid"))
            {
                decimal predictedProfit = (track.StreamCount * 0.01m) - (track.Advance * 0.8m);
                results.Add(new DepartmentModel
                {
                    Department = "Acid",
                    PredictedProfit = predictedProfit,
                    ApprovalRequired = predictedProfit < 1200 //threshold
                });
            }

            if (!track.Tags.Any() || track.Tags.Contains(string.Empty) || track.Tags.Any(tag => !definedTags.Contains(tag)))               
            {
                decimal defaultPredictedProfit = (track.StreamCount * 0.008m) - track.Advance;
                results.Add(new DepartmentModel
                {
                    Department = "Default",
                    PredictedProfit = defaultPredictedProfit,
                    ApprovalRequired = defaultPredictedProfit < 1100 //threshold
                });
            }

            return results;
        }
    }
}
