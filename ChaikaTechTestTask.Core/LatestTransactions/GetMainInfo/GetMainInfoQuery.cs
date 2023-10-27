using MediatR;

namespace ChaikaTechTestTask.Core.LatestTransactions.GetMainInfo;

public class GetMainInfoQuery : IRequest<GetMainInfo>
{
    public int UserId { get; set; }
}
