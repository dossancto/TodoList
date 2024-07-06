namespace TodoList.Src.TodoList.Src.Features.Colors.Domain.Entities;

// Genreate xml documentation for this class
/// <summary>
/// Represents a color domain object
/// </summary>
public record Color(string Name, string Description, string HexCode)
{
    public Color() : this("", "", "") { }
}
