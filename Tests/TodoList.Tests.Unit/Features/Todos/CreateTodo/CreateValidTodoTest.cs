using System.ComponentModel;
using TodoList.Src.Features.Todos.Application.CreateTodo;
using TodoList.Src.Features.Todos.Domain.Entities;
using TodoList.Src.Features.Todos.Domain.Ports;

namespace TodoList.Tests.Unit.Features.Todos.CreateTodo;

public class CreateValidTodoTest
{
    [Fact]
    public async Task CreteValidTodo_Should_ReturnCreatedTodo()
    {
        // Given
        var createTodoValidator = new CreateTodoValidation();

        var todoRepository = Substitute.For<ITodoRepository>();

        todoRepository.Create(Arg.Any<Todo>()).Returns("123");

        var createTodoInput = new CreateTodoInput(
            Name: "Completar o curso"
            );

        var usecase = new CreateTodoUsecase(createTodoValidator, todoRepository);

        // When
        var todo = await usecase.Execute(createTodoInput);

        // Then
        todo.Id.Should().Be("123");
        todo.Name.Should().Be("Completar o curso");
        todo.Description.Should().Be("none");

        await todoRepository.Received(1).Create(Arg.Any<Todo>());
    }

    [Fact]
    public async Task CreteValidTodoWithDescription_Should_ReturnCreatedTodoWithDeclaredDescription()
    {
        // Given
        var createTodoValidator = new CreateTodoValidation();

        var todoRepository = Substitute.For<ITodoRepository>();

        todoRepository.Create(Arg.Any<Todo>()).Returns("123");

        var createTodoInput = new CreateTodoInput(
            Name: "Completar o curso",
            Description: "No começo"
            );

        var usecase = new CreateTodoUsecase(createTodoValidator, todoRepository);

        // When
        var todo = await usecase.Execute(createTodoInput);

        // Then
        todo.Id.Should().Be("123");
        todo.Name.Should().Be("Completar o curso");
        todo.Description.Should().Be("No começo");
    }
}
