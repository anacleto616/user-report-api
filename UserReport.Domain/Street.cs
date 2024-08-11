namespace UserReport.Domain;

public class Street
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public required string Name { get; set; }
}
