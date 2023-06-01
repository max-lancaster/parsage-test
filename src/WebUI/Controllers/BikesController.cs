using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Bikes.Queries;
using parsage_test.Application.TodoItems.Commands.CreateTodoItem;

namespace parsage_test.WebUI.Controllers;

public class BikesController: ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<BikesVm>> Get()
    {
        return await Mediator.Send(new GetBikesQuery());
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
    }
}