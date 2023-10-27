using AutoMapper;
using ChaikaTechTestTask.Core.Context;
using ChaikaTechTestTask.Core.Points;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChaikaTechTestTask.Core.LatestTransactions.GetMainInfo;

public class GetMainInfoQueryHandler : IRequestHandler<GetMainInfoQuery, GetMainInfo>
{
    private const int AVAILABLE_BALANCE = 1500;

    private readonly ChaikaTechDbContext _context;
    private readonly IMapper _mapper;

    public GetMainInfoQueryHandler(ChaikaTechDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetMainInfo> Handle(GetMainInfoQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == request.UserId);

        if (user == null)
        {
            throw new ArgumentException("User not found!");
        }

        var lastWeekDateTime = DateTime.Now.Date.AddDays(-7);
        var lastWeekDate = DateOnly.FromDateTime(lastWeekDateTime);

        var currentMonth = DateTime.Now.ToString("MMMM");
        var capitalizedMonth = currentMonth.Substring(0, 1).ToUpper() + currentMonth.Substring(1);
        var message = $"You’ve paid your {capitalizedMonth} balance.";

        var dailyPointsCalc = new DailyPointsCalculator(_context);
        var dailyPointsDecimal = await dailyPointsCalc.CalculateDailyPointsForUser(user.UserId);
        var dailyPointsString = FormatDailyPoints((int)Math.Floor(dailyPointsDecimal));

        var transactions = await _context.LatestTransactions
            .Where(t => t.UserId == user.UserId)
            .OrderByDescending(t => t.TransactionDate)
            .Take(10)
            .ToListAsync();

        var latestTransaction = transactions.LastOrDefault();
        var availableBalance = AVAILABLE_BALANCE - (latestTransaction?.Balance ?? 0);

        var latestTransactionViewModels = transactions.Select(transaction =>
        {
            var latestTransactionViewModel = _mapper.Map<LatestTransactionViewModel>(transaction);
            latestTransactionViewModel.Amount = transaction.Transaction == TransactionType.Payment
                ? "+" + transaction.Amount.ToString("N2")
                : transaction.Amount.ToString("N2");
            latestTransactionViewModel.TransactionDate = transaction.TransactionDate >= lastWeekDate
                ? transaction.TransactionDate.DayOfWeek.ToString()
                : transaction.TransactionDate.ToString("dd.MM.yyyy");
            return latestTransactionViewModel;
        }).ToList();

        var cardBalance = (latestTransaction?.Balance ?? 0).ToString("N2");

        return new GetMainInfo
        {
            CardBalance = cardBalance,
            AvailableBalance = availableBalance.ToString("N2"),
            PaymentDue = message,
            DailyPoints = dailyPointsString,
            Transactions = latestTransactionViewModels
        };
    }

    private string FormatDailyPoints(int points)
    {
        return points >= 1000 ? (points / 1000) + "k" : points.ToString();
    }
}
