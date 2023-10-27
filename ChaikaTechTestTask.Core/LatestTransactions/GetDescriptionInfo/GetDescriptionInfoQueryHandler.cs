using AutoMapper;
using ChaikaTechTestTask.Core.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTechTestTask.Core.LatestTransactions.GetDescriptionInfo
{
    public class GetDescriptionInfoQueryHandler : IRequestHandler<GetDescriptionInfoQuery, GetDescriptionInfo>
    {
        private readonly ChaikaTechDbContext _context;
        private readonly IMapper _mapper;

        public GetDescriptionInfoQueryHandler(ChaikaTechDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetDescriptionInfo> Handle(GetDescriptionInfoQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _context.LatestTransactions.FirstOrDefaultAsync(t => t.TransactionId == request.TransactionId);

            if (transaction == null)
            {
                throw new ArgumentException("Transaction not found!");
            }

            var descriptionInfo = _mapper.Map<GetDescriptionInfo>(transaction);

            var lastWeekDateTime = DateTime.Now.Date.AddDays(-7);
            var lastWeekDate = DateOnly.FromDateTime(lastWeekDateTime);

            string timeAndDate = transaction.TransactionDate >= lastWeekDate
                ? $"{transaction.TransactionDate.DayOfWeek}, {transaction.TransactionTime}"
                : $"{transaction.TransactionDate}, {transaction.TransactionTime}";

            descriptionInfo.Amount = transaction.Transaction == TransactionType.Payment
                ? "+" + transaction.Amount.ToString("N2")
                : transaction.Amount.ToString("N2");

            if (!string.IsNullOrEmpty(transaction.AuthorizedUser))
            {
                timeAndDate = $"{transaction.AuthorizedUser} - {timeAndDate}";
            }

            descriptionInfo.TransactionDateTime = timeAndDate;

            descriptionInfo.Status = transaction.IsPending ? "Status: Not Approved" : "Status: Approved";

            return descriptionInfo;
        }
    }
}
