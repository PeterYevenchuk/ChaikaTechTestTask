using MediatR;

namespace ChaikaTechTestTask.Core.LatestTransactions.GetDescriptionInfo;

public class GetDescriptionInfoQuery : IRequest<GetDescriptionInfo>
{
    public int TransactionId { get; set; }
}
