namespace UserReport.Domain;

public class Picture
{
    public Guid Id { get; set; }
    public required string Large { get; set; }
    public required string Medium { get; set; }
    public required string Thumbnail { get; set; }
}
