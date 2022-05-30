using EF.Domian.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Infraestructure.EntityConfiguration
{
    public class TodoEntityConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .HasIndex(t => t.Description)
                .IsUnique();
        }
    }
}
