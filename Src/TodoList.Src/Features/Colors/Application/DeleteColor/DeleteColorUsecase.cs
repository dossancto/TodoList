using TodoList.Src.TodoList.Src.Features.Colors.Domain.Ports;

namespace TodoList.Src.TodoList.Src.Features.Colors.Application.DeleteColor;

public class DeleteColorUsecase(
    IColorRepository _colorRepository
    )
{
    private readonly IColorRepository colorRepository = _colorRepository;

    public async Task Execute(DeleteColorInput input)
    {
        await colorRepository.Delete(input);
    }
}

