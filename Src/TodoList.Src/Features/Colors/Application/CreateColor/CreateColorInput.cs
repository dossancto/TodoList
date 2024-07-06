using TodoList.Src.TodoList.Src.Features.Colors.Domain.Entities;

namespace TodoList.Src.TodoList.Src.Features.Colors.Application.CreateColor;

public record CreateColorInput(string Name, string Description, string HexCode)
{
    public Color ToColor()
      => new()
      {
          Name = Name,
          Description = Description,
          HexCode = HexCode
      };

}

