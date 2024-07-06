using TodoList.Src.Features.Todos.Application.CreateTodo;
using TodoList.Src.Features.Todos.Application.DeleteTodo;
using TodoList.Src.Features.Todos.Application.SelectTodo;
using TodoList.Src.TodoList.Src.Features.Todos.Application.CompleteTodo;

namespace TodoList.Src.Features.Todos.Adapters.Injectors;

public static class TodoUsecaseInjectors
{
    public static IServiceCollection AddTodoUsecases(this IServiceCollection services)
    => services
            .AddScoped<SelectTodoUsecase>()
            .AddScoped<CreateTodoUsecase>()
            .AddScoped<DeleteTodoUsecase>()
            .AddScoped<CompleteTodoUsecase>()
    ;
}
