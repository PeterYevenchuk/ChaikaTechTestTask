using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ChaikaTechTestTask.Core.Points;

namespace ChaikaTechTestTask.Core.Users;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public string Name { get; set; }

    public Point Point { get; set; }
}
