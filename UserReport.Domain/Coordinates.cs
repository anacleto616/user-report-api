namespace UserReport.Domain;

public class Coordinates
{
    public Guid Id { get; set; }
    public required string Latitude { get; set; }
    public required string Longitude { get; set; }
}
