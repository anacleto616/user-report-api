namespace UserReport.Domain;

public class Timezone
{
    public Guid Id { get; set; }
    public required string Offset { get; set; }
    public required string Description { get; set; }
}
