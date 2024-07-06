using TodoList.Src.Features.Commum.Adapters.Database.EntityFramework.Contexts;
using TodoList.Src.Features.Todos.Adapters.Database.Models;
using TodoList.Src.Features.Todos.Domain.Entities;
using TodoList.Src.Features.Todos.Domain.Ports;

namespace TodoList.Src.Features.Todos.Adapters.Database.Repositories;

public class PostgresTodoRepository(
    ApplicationDbContext context
) : ITodoRepository
{
    public async Task<string> Create(Todo todo)
    {
        var id = Guid.NewGuid().ToString();

        var model = PostgresTodo.AsPostgres(todo);

        model.Id = id;

        context.Todos.Add(model);

        await context.SaveChangesAsync();

        return id;
    }
}