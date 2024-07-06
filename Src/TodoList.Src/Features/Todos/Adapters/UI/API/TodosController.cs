using Microsoft.AspNetCore.Mvc;
using TodoList.Src.Features.Todos.Application.CreateTodo;
using TodoList.Src.Features.Todos.Application.SelectTodo;

namespace TodoList.Src.Features.Todos.Adapters.UI.API;

[ApiController]
[Route("[controller]")]
public class TodosController(
    CreateTodoUsecase createTodo,
    SelectTodoUsecase selectTodo
) : ControllerBase
{
    private readonly CreateTodoUsecase _createTodo = createTodo;
    private readonly SelectTodoUsecase selectTodo = selectTodo;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTodoInput request)
    {
        var res = await _createTodo.Execute(request);

        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var todo = await selectTodo.Execute(new SelectTodoByIdInput(
            Id: id
        ));

        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    => Ok(await selectTodo.Execute(new SelectAllTodos()));
}