using Microsoft.EntityFrameworkCore;

using TrackSplitter.DataAccess.Config;
using TrackSplitter.DataAccess.Models;

namespace TrackSplitter.DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<TrackInfo> Tracks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TrackInfoConfig());
    }
}
