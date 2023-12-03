namespace TrackDefinitionsAPI.RequestModels
{
    public class TrackDefinition
    {
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public double StreamCount { get; set; }
        public double Advance { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
