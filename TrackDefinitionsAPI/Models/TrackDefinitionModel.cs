using System.ComponentModel.DataAnnotations;

namespace TrackDefinitionsAPI.Models
{
    public class TrackDefinitionModel
    {
       public string Title { get; set; } = string.Empty;
       public string Artist { get; set; } = string.Empty;
       public List<string> Tags { get; set; } = new List<string>();
       public int StreamCount { get; set; }
       public decimal Advance { get; set; }

    }
}
