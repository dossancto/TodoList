namespace TodoList.Src.TodoList.Src.Features.Todos.Domain.Exceptions;

/// <summary>
/// Error when Todo already been processed
/// </summary>  
public class TodoAlrearyBeenProcessedException(string msg) : Exception(msg)
{
    public TodoAlrearyBeenProcessedException() : this("This todo is already been processed")
    {

    }
}
