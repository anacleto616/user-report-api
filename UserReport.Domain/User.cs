namespace UserReport.Domain;

using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(UserId))]
public class User
{
    public Guid UserId { get; set; }
    public required string Gender { get; set; }
    public required Name Name { get; set; }
    public required Location Location { get; set; }
    public required string Email { get; set; }
    public required Login Login { get; set; }
    public required DateOfBirth Dob { get; set; }
    public required Registered Registered { get; set; }
    public required string Phone { get; set; }
    public required string Cell { get; set; }
    public required Identification Id { get; set; }
    public required Picture Picture { get; set; }
    public required string Nat { get; set; }
}
