using Amazon.DynamoDBv2.DataModel;
using TodoList.Src.TodoList.Src.Features.Colors.Domain.Entities;

namespace TodoList.Src.TodoList.Src.Features.Colors.Adapters.Database.Entities;

[DynamoDBTable("colors")]
public record DynamoColorEntity(
    [property: DynamoDBHashKey("color")]
    string Name,
    [property: DynamoDBProperty]
    string Description,
    [property: DynamoDBProperty]
    string HexCode
    )
{
    /// <summary>
    /// Converts from a Color
    /// </summary>
    public DynamoColorEntity(Color c) : this(c.Name, c.Description, c.HexCode) { }

    /// <summary>
    /// Empty controller
    /// </summary>
    public DynamoColorEntity() : this("", "", "") { }

    /// <summary>
    /// Convert to Color
    /// </summary>
    /// <returns>The Entity</returns>
    public Color ToColor()
      => new(Name: Name,
            Description: Description,
            HexCode: HexCode
        );
}
