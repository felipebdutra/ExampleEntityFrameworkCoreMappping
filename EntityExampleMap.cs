using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp1.EntityFrameworkCoreExample
{
    public class EntityExampleMap : IEntityTypeConfiguration<EntityExample>
    {
       public void Configure(EntityTypeBuilder<EntityExample> builder)
        {
            builder.ToTable("myTable");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .HasValueGenerator((_, __) => new SequenceValueGenerator("database", "otherParam"));
                
            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Name");
        }
    }
}