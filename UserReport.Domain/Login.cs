namespace UserReport.Domain;

public class Login
{
    public Guid Id { get; set; }
    public required string Uuid { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Salt { get; set; }
    public required string Md5 { get; set; }
    public required string Sha1 { get; set; }
    public required string Sha256 { get; set; }
}
