using Microsoft.AspNetCore.Mvc;
using TodoList.Src.Features.Todos.Application.CreateTodo;
using TodoList.Src.Features.Todos.Application.DeleteTodo;
using TodoList.Src.Features.Todos.Application.SelectTodo;
using TodoList.Src.TodoList.Src.Features.Todos.Application.CompleteTodo;

namespace TodoList.Src.Features.Todos.Adapters.UI.API;

[ApiController]
[Route("[controller]")]
public class TodosController(
    CreateTodoUsecase createTodo,
    SelectTodoUsecase selectTodo,
    CompleteTodoUsecase completeTodo,
    DeleteTodoUsecase deleteTodo
) : ControllerBase
{
    private readonly CreateTodoUsecase _createTodo = createTodo;
    private readonly SelectTodoUsecase selectTodo = selectTodo;
    private readonly CompleteTodoUsecase completeTodo = completeTodo;
    private readonly DeleteTodoUsecase deleteTodo = deleteTodo;

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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await deleteTodo.Execute(new(id));

        return Ok("Deletado paizao");
    }

    [HttpPatch("complete/{id}")]
    public async Task<IActionResult> Complete(string id)
    {
        var messageId = await completeTodo.Execute(new ProcessCompleteTodoInput(
              TodoId: id
          ));

        return Accepted(messageId);
    }
}
