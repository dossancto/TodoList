using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Src.Features.Todos.Adapters.Database.Models;

namespace TodoList.Src.Features.Todos.Adapters.Database.Configurations;

public class PostgresTodoConfiguration : IEntityTypeConfiguration<PostgresTodo>
{
    public void Configure(EntityTypeBuilder<PostgresTodo> b)
    {
        b.ToTable("todos");

        b.HasKey(x => x.Id);
        b.Property(x => x.Id).HasMaxLength(36);
        b.Property(x => x.Id).ValueGeneratedOnAdd();

        b.Property(x => x.Name).HasMaxLength(255).IsRequired();

        b.Property(x => x.Description).HasMaxLength(512).IsRequired();

        b.Property(x => x.CreatedAt).ValueGeneratedOnAdd();
    }
}