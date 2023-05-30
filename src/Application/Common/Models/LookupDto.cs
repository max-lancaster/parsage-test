using parsage_test.Application.Common.Mappings;
using parsage_test.Domain.Entities;

namespace parsage_test.Application.Common.Models;

// Note: This is currently just used to demonstrate applying multiple IMapFrom attributes.
public class LookupDto : IMapFrom<TodoList>, IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public string? Title { get; set; }
}
