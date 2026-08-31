using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TrackSplitter.DataAccess.Models;

namespace TrackSplitter.DataAccess.Config;

public class TrackInfoConfig : IEntityTypeConfiguration<TrackInfo>
{
    public void Configure(EntityTypeBuilder<TrackInfo> builder)
    {
        builder.HasKey(p => p.Id);
    }
}
