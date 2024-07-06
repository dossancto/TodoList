using System.Data;
using FluentValidation;

namespace TodoList.Src.Features.Todos.Application.CreateTodo;

public class CreateTodoValidation : AbstractValidator<CreateTodoInput>
{
    public CreateTodoValidation()
    {
        RuleFor(x => x.Name).Length(3, 255).NotEmpty();

        RuleFor(x => x.Description)
                    .MaximumLength(512)
                    .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}

