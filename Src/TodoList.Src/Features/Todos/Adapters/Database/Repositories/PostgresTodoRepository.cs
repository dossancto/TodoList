using TodoList.Src.Features.Commum.Adapters.Database.EntityFramework.Contexts;
using TodoList.Src.Features.Todos.Adapters.Database.Models;
using TodoList.Src.Features.Todos.Domain.Entities;
using TodoList.Src.Features.Todos.Domain.Ports;

namespace TodoList.Src.Features.Todos.Adapters.Database.Repositories;

public class PostgresTodoRepository(
    ApplicationDbContext context
) : ITodoRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<string> Create(Todo todo)
    {
        var id = Guid.NewGuid().ToString();

        var model = PostgresTodo.AsPostgres(todo);

        model.Id = id;

        _context.Todos.Add(model);

        await _context.SaveChangesAsync();

        return id;
    }
}