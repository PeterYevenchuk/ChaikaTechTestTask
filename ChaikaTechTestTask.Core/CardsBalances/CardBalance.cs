using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ChaikaTechTestTask.Core.Users;

namespace ChaikaTechTestTask.Core.CardsBalances;

public class CardBalance
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CardBalanceId { get; set; }

    public decimal UserCardBalance {  get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
