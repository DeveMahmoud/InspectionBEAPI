using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ViolationConfiguration : IEntityTypeConfiguration<Violation> {
    public void Configure(EntityTypeBuilder<Violation> builder) {
        builder.ToTable("Violations"); builder.HasKey(v => v.Id);
        builder.Property(v => v.Code).IsRequired().HasMaxLength(50);
        builder.Property(v => v.Description).IsRequired().HasMaxLength(500);
        builder.Property(v => v.Severity).HasConversion<string>().IsRequired();
    }
}
