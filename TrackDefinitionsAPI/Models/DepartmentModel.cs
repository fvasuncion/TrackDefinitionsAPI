namespace TrackDefinitionsAPI.Models
{
    public class DepartmentModel
    {
        public string Department { get; set; } = string.Empty;
        public decimal PredictedProfit { get; set; }
        public bool ApprovalRequired { get; set; }
    }
}
