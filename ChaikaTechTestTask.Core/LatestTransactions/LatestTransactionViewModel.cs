namespace ChaikaTechTestTask.Core.LatestTransactions;

public class LatestTransactionViewModel
{
    public int TransactionId { get; set; }

    public string Transaction { get; set; }

    public decimal Amount { get; set; }

    public string TransactionName { get; set; }

    public string Description { get; set; }

    public string TransactionDate { get; set; }

    public bool IsPending { get; set; }

    public string? AuthorizedUser { get; set; }

    public string? IconURL { get; set; }
}
