using System.Globalization;
using parsage_test.Application.Common.Interfaces;
using parsage_test.Application.TodoLists.Queries.ExportTodos;
using parsage_test.Infrastructure.Files.Maps;
using CsvHelper;

namespace parsage_test.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
