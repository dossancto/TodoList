using Microsoft.EntityFrameworkCore;
using TodoList.Src.Features.Commum.Adapters.Database.EntityFramework.Contexts;
using TodoList.Src.Features.Todos.Adapters.Database.Postgres.Models;
using TodoList.Src.Features.Todos.Application.DeleteTodo;
using TodoList.Src.Features.Todos.Application.SelectTodo;
using TodoList.Src.Features.Todos.Domain.Entities;
using TodoList.Src.Features.Todos.Domain.Ports;

namespace TodoList.Src.Features.Todos.Adapters.Database.Postgres.Repositories;

public class PostgresTodoRepository(
    ApplicationDbContext context
) : ITodoRepository
{
    public async Task<IEnumerable<Todo>> All(SelectAllTodos input)
    => (await context.Todos.ToListAsync()).Select(x => x.AsEntity());

    public async Task<string> Create(Todo todo)
    {
        var id = Guid.NewGuid().ToString();

        var model = PostgresTodo.AsPostgres(todo);

        context.Todos.Add(model with { Id = id });

        await context.SaveChangesAsync();

        return id;
    }

    public async Task Delete(DeleteTodoInput input)
    {
        var todo = await context.Todos.FindAsync(input.Id);

        if (todo is null)
        {
            return;
        }

        context.Todos.Remove(todo);

        await context.SaveChangesAsync();
    }

    public async Task<Todo?> FindById(SelectTodoByIdInput input)
    => (await context.Todos.FindAsync(input.Id))?.AsEntity();
}
