using Microsoft.AspNetCore.Mvc;
using TodoList.Src.TodoList.Src.Features.Colors.Application.CreateColor;
using TodoList.Src.TodoList.Src.Features.Colors.Application.DeleteColor;
using TodoList.Src.TodoList.Src.Features.Colors.Application.SelectColor;

namespace TodoList.Src.TodoList.Src.Features.Colors.Adapters.UI.API;

[ApiController]
[Route("colors")]
public class ColorsController(
    CreateColorUsecase _createColor,
    DeleteColorUsecase _deleteColor,
    SelectColorUsecase _selectColor
    ) : ControllerBase
{
    private readonly CreateColorUsecase createColor = _createColor;
    private readonly DeleteColorUsecase deleteColor = _deleteColor;
    private readonly SelectColorUsecase selectColor = _selectColor;

    [HttpPut]
    public async Task<IActionResult> Create([FromBody] CreateColorInput input)
    {
        var result = await createColor.Execute(input);

        return Ok(result);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetColorByName(string name)
    {
        var input = new SelectColorInput(ColorName: name);

        var color = await selectColor.Execute(input);

        if (color is null)
        {
            return NotFound();
        }

        return Ok(color);
    }


    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteColorByName(string name)
    {
        var input = new DeleteColorInput(
            Name: name
            );

        await deleteColor.Execute(input);

        return Ok("Color deleted");
    }
}
