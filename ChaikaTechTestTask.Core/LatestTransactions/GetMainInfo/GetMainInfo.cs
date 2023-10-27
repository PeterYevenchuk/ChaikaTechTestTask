namespace ChaikaTechTestTask.Core.LatestTransactions.GetMainInfo;

public class GetMainInfo
{
    public decimal CardBalance { get; set; }

    public decimal AvailableBalance { get; set; }

    public string PaymentDue {  get; set; }

    public int DailyPoints { get; set; }

    public List<LatestTransactionViewModel> Transactions { get; set; }
}
