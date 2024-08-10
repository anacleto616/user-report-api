namespace UserReport.Domain;

public class Location
{
    public int Id { get; set; }
    public required Street Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string Postcode { get; set; }
    public required Coordinates Coordinates { get; set; }
    public required Timezone Timezone { get; set; }
}
