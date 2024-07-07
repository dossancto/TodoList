using Amazon.DynamoDBv2.DataModel;
using TodoList.Src.TodoList.Src.Features.Todos.Domain.Entities;

namespace TodoList.Src.TodoList.Src.Features.Todos.Adapters.Database.Dynamo.Entities;

[DynamoDBTable("processing_todos")]
public record DynamoProcessingTodo(
    [property: DynamoDBHashKey("todo_id")]
    string TodoId,

    DateTime StartProcessing
    )
{
    public DynamoProcessingTodo(ProcessingTodo todo) : this(todo.TodoId, todo.StartProcessing) { }

    public DynamoProcessingTodo() : this(string.Empty, DateTime.UtcNow) { }

    public ProcessingTodo AsEntity()
      => new(
          TodoId: TodoId,
          StartProcessing: StartProcessing
        );
}
