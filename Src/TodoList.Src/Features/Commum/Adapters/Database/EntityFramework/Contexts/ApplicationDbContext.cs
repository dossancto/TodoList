using Microsoft.EntityFrameworkCore;
using TodoList.Src.Features.Todos.Adapters.Database.Models;

namespace TodoList.Src.Features.Commum.Adapters.Database.EntityFramework.Contexts;

public class ApplicationDbContext(DbContextOptions options): DbContext(options)
{
    public DbSet<PostgresTodo> Todos {get;} = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
    }

}