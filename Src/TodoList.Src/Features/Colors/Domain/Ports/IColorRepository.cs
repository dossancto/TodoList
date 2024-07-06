using TodoList.Src.TodoList.Src.Features.Colors.Application.DeleteColor;
using TodoList.Src.TodoList.Src.Features.Colors.Application.SelectColor;
using TodoList.Src.TodoList.Src.Features.Colors.Domain.Entities;

namespace TodoList.Src.TodoList.Src.Features.Colors.Domain.Ports;

public interface IColorRepository
{
    /// <summary>
    /// Get a color by name
    /// </summary>
    /// <param name="input"> The color name </param>
    Task<Color?> GetColorByName(SelectColorInput input);

    /// <summary>
    /// Create a new color
    /// </summary>
    /// <param name="c"> The color to be saved </param>
    Task Create(Color c);

    /// <summary>
    /// Delete a color
    /// </summary>
    /// <param name="input"> The color to be deleted </param>
    Task Delete(DeleteColorInput input);
}
