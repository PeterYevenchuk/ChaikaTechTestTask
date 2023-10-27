using ChaikaTechTestTask.Core.LatestTransactions.GetMainInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChaikaTechTestTask.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public MainInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetTest(int userId)
    {
        var query = new GetMainInfoQuery { UserId = userId };
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
