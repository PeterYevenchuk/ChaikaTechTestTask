namespace ChaikaTechTestTask.Core.LatestTransactions.GetMainInfo;

public class GetMainInfo
{
    public string CardBalance { get; set; }

    public string AvailableBalance { get; set; }

    public string PaymentDue {  get; set; }

    public string DailyPoints { get; set; }

    public List<LatestTransactionViewModel> Transactions { get; set; }
}
