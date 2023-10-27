using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ChaikaTechTestTask.Core.Users;

namespace ChaikaTechTestTask.Core.Points;

public class Point
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PointId { get; set; }

    public double BeforeYesterdayPoints { get; set; }

    public double YesterdayPoints { get; set; }

    public double TodayPoints { get; set; }

    public double TotalPoints { get; set; }

    public DateTime TodayDate { get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
