using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InspectionVisitConfiguration : IEntityTypeConfiguration<InspectionVisit> {
    public void Configure(EntityTypeBuilder<InspectionVisit> builder) {
        builder.ToTable("InspectionVisits"); builder.HasKey(v => v.Id);
        builder.Property(v => v.ScheduledAt).IsRequired();
        builder.Property(v => v.Status).HasConversion<string>().IsRequired();
        builder.Property(v => v.Score);
        builder.Property(v => v.Notes).HasMaxLength(1000);
        builder.HasOne(v => v.Inspector).WithMany().HasForeignKey(v => v.InspectorId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(v => v.Violations).WithOne(x => x.InspectionVisit).HasForeignKey(x => x.InspectionVisitId).OnDelete(DeleteBehavior.Cascade);
    }
}
