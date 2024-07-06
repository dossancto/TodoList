using FluentValidation;
using TodoList.Src.Features.Todos.Domain.Entities;
using TodoList.Src.Features.Todos.Domain.Ports;

namespace TodoList.Src.Features.Todos.Application.CreateTodo;

public class CreateTodoUsecase(
    IValidator<CreateTodoInput> createTodoValidator,
    ITodoRepository todoRepository
    )
{
    private readonly IValidator<CreateTodoInput> _createTodoValidator = createTodoValidator;

    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<Todo> Execute(CreateTodoInput input)
    {
        var validationResult = _createTodoValidator.Validate(input);

        if (!validationResult.IsValid)
        {
            throw new Exception("A model não ta valida");
        }

        // Meu todo é valido

        var todoEntity = input.ToTodo();

        var todoId = await _todoRepository.Create(todoEntity);

        return todoEntity with { Id = todoId };
    }
}
