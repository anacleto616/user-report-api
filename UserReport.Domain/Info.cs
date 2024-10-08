namespace UserReport.Domain;

public class Info
{
    public Guid Id { get; set; }
    public required string Seed { get; set; }
    public int Results { get; set; }
    public int Page { get; set; }
    public required string Version { get; set; }
}
