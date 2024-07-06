using TodoList.Src.Features.Todos.Application.CreateTodo;
using TodoList.Src.Features.Todos.Domain.Entities;
using TodoList.Src.Features.Todos.Domain.Ports;

namespace TodoList.Tests.Unit.Features.Todos.CreateTodo;

public class CreateTodoInvalidTest
{
    [Fact]
    public async Task CreateTodoWithInsuficnetChars_Should_ReturnValidationFailAsync()
    {
        // Given
        var createTodoValidator = new CreateTodoValidation();

        var todoRepository = Substitute.For<ITodoRepository>();

        todoRepository.Create(Arg.Any<Todo>()).Returns("123");

        var createTodoInput = new CreateTodoInput()
        {
            Name = "12",
        };

        var usecase = new CreateTodoUsecase(createTodoValidator, todoRepository);

        // When
        var task = () => usecase.Execute(createTodoInput);

        await Assert.ThrowsAsync<Exception>(task);

        await todoRepository.DidNotReceive().Create(Arg.Any<Todo>());
    }
}