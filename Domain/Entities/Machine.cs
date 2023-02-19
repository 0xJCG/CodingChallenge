using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public record class Machine
    {
        [property: JsonPropertyName("id")] public Guid ID { get; set; }
        [property: JsonPropertyName("name")] public string? Name { get; set; }
        [property: JsonPropertyName("manufacturer")] public string? Manufacturer { get; set; }
        [property: JsonPropertyName("technology")] public int Technology { get; set; }
    }
}
