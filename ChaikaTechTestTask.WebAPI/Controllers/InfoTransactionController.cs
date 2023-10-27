using ChaikaTechTestTask.Core.LatestTransactions.GetDescriptionInfo;
using ChaikaTechTestTask.Core.LatestTransactions.GetMainInfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChaikaTechTestTask.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InfoTransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public InfoTransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetMainInfoByUserId(int userId)
    {
        var query = new GetMainInfoQuery { UserId = userId };
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("get-transaction/{transactionId}")]
    public async Task<IActionResult> GetTransactionInfoById(int transactionId)
    {
        var query = new GetDescriptionInfoQuery { TransactionId = transactionId };
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
