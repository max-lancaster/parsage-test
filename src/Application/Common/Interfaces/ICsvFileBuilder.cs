using parsage_test.Application.TodoLists.Queries.ExportTodos;

namespace parsage_test.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
