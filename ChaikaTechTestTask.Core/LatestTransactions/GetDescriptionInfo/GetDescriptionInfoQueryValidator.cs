using FluentValidation;

namespace ChaikaTechTestTask.Core.LatestTransactions.GetDescriptionInfo;

public class GetDescriptionInfoQueryValidator : AbstractValidator<GetDescriptionInfoQuery>
{
    public GetDescriptionInfoQueryValidator()
    {
        RuleFor(u => u).NotEmpty();
        RuleFor(u => u.TransactionId).GreaterThan(0);
    }
}
