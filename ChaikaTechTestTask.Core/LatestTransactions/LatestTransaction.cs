using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ChaikaTechTestTask.Core.Users;

namespace ChaikaTechTestTask.Core.LatestTransactions;

public class LatestTransaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TransactionId { get; set; }

    public TransactionType Transaction { get; set; }

    public decimal Amount { get; set; }

    public decimal Balance { get; set; }

    public string TransactionName { get; set; }

    public string Description { get; set; }

    public DateOnly TransactionDate {  get; set; }

    public TimeOnly TransactionTime { get; set; }

    public bool IsPending { get; set; }

    public string? AuthorizedUser { get; set; }

    public string? IconURL { get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
