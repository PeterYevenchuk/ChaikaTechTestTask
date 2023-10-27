namespace ChaikaTechTestTask.Core.LatestTransactions;

public class LatestTransactionViewModel
{
    public int TransactionId { get; set; }

    public string Amount { get; set; }

    public string TransactionName { get; set; }

    public string Description { get; set; }

    public string TransactionDate { get; set; }

    public string? IconURL { get; set; }
}
