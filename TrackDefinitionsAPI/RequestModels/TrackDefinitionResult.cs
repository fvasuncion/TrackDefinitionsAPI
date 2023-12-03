namespace TrackDefinitionsAPI.RequestModels
{
    public class TrackDefinitionResult
    {
        public string Department { get; set; } = string.Empty;
        public double PredictedProfit { get; set; }
        public bool ApprovalRequired { get; set; }
    }
}
