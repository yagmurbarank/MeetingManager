using MeetingManager.Areas.Identity.Data;
using MeetingManager.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeetingManager.Data;

public class MeetingDbContext : IdentityDbContext<ApplicationUser>
{
    public MeetingDbContext(DbContextOptions<MeetingDbContext> options)
        : base(options)
    {
    }
    public DbSet<Meeting> Meetings { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
