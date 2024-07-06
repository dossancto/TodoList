using TodoList.Src.TodoList.Src.Features.Colors.Domain.Entities;
using TodoList.Src.TodoList.Src.Features.Colors.Domain.Ports;

namespace TodoList.Src.TodoList.Src.Features.Colors.Application.CreateColor;

public class CreateColorUsecase(
    IColorRepository _colorRepository
    )
{
    private readonly IColorRepository colorRepository = _colorRepository;

    public async Task<Color> Execute(CreateColorInput input)
    {
        var entity = input.ToColor();

        await colorRepository.Create(entity);

        return entity;
    }
}
