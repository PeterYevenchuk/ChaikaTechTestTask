using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ChaikaTechTestTask.Core.Users;

namespace ChaikaTechTestTask.Core.Points;

public class Point
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PointId { get; set; }

    public int BeforeYesterdayPoints { get; set; }

    public int YesterdayPoints { get; set; }

    public int TotalPoints { get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
