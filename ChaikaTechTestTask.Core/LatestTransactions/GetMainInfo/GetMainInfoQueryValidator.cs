using FluentValidation;

namespace ChaikaTechTestTask.Core.LatestTransactions.GetMainInfo;

public class GetMainInfoQueryValidator : AbstractValidator<GetMainInfoQuery>
{
    public GetMainInfoQueryValidator()
    {
        RuleFor(u => u).NotEmpty();
        RuleFor(u => u.UserId).GreaterThan(0);
    }
}
