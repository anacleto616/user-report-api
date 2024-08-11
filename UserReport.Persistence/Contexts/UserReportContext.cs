namespace UserReport.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using UserReport.Domain;

public class UserReportContext(DbContextOptions<UserReportContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Name> Names { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Coordinates> Coordinates { get; set; }
    public DbSet<Timezone> Timezones { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<DateOfBirth> DateOfBirths { get; set; }
    public DbSet<Registered> Registereds { get; set; }
    public DbSet<Identification> Identifications { get; set; }
    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Info> Infos { get; set; }
}
