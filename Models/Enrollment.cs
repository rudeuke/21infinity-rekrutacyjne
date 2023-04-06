using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _21infinity_rekrutacja_core.Models;

public partial class Enrollment
{
    [Key]
    public long Id { get; set; }

    [ForeignKey(nameof(UserAccount))]
    public long UserId { get; set; }

    public UserAccount? UserAccount { get; set; }

    [ForeignKey(nameof(Training))]
    public long TrainingId { get; set; }

    public Training? Training { get; set; }

    public DateTime AvailableFrom { get; set; }

    public DateTime AvailableTo { get; set; }
}
