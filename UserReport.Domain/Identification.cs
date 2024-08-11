namespace UserReport.Domain;

public class Identification
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Value { get; set; }
}
