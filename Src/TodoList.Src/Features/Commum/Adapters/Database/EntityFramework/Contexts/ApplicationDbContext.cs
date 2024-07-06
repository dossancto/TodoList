using Microsoft.EntityFrameworkCore;

namespace TodoList.Src.Features.Commum.Adapters.Database.EntityFramework.Contexts;

public class ApplicationDbContext(DbContextOptions options): DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
    }

}