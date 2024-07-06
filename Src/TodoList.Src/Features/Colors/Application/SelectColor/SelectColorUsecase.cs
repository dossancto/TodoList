using TodoList.Src.TodoList.Src.Features.Colors.Domain.Entities;
using TodoList.Src.TodoList.Src.Features.Colors.Domain.Ports;

namespace TodoList.Src.TodoList.Src.Features.Colors.Application.SelectColor;

public class SelectColorUsecase(
IColorRepository colorRepository
    )
{
    private readonly IColorRepository _colorRepository = colorRepository;

    public Task<Color?> Execute(SelectColorInput input)
      => _colorRepository.GetColorByName(input);
}
