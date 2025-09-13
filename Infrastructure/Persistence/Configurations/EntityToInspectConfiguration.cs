using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EntityToInspectConfiguration : IEntityTypeConfiguration<EntityToInspect> {
    public void Configure(EntityTypeBuilder<EntityToInspect> builder) {
        builder.ToTable("EntitiesToInspect"); builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Address).IsRequired().HasMaxLength(300);
        builder.Property(e => e.Category).IsRequired().HasMaxLength(100);
        builder.HasMany(e => e.Visits).WithOne(v => v.EntityToInspect).HasForeignKey(v => v.EntityToInspectId).OnDelete(DeleteBehavior.Cascade);
    }
}
