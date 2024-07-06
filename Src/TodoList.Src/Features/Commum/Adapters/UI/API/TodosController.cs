using Microsoft.AspNetCore.Mvc;
using TodoList.Src.Features.Todos.Application.CreateTodo;

namespace TodoList.Src.Features.Commum.Adapters.UI.API;

[ApiController]
[Route("[controller]")]
public class TodosController(
    CreateTodoUsecase createTodo
) : ControllerBase
{
    private readonly CreateTodoUsecase _createTodo = createTodo;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTodoInput request)
    {
        var res = await _createTodo.Execute(request);

        return Ok(res);
    }
}