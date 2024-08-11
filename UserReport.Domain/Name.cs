namespace UserReport.Domain;

public class Name
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string First { get; set; }
    public required string Last { get; set; }
}
