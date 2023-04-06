using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _21infinity_rekrutacja_core.Models;

public partial class Training
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }

    [ForeignKey(nameof(UserAccount))]
    public long OwnerId { get; set; }

    public UserAccount? Owner { get; set; }

    public ICollection<Enrollment>? Enrollments { get; set; }

    public ICollection<Question>? Questions { get; set; }
}
