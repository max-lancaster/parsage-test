using parsage_test.Application.Common.Mappings;
using parsage_test.Domain.Entities;

namespace parsage_test.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
