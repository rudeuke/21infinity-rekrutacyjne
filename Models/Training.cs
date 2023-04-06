using System.ComponentModel.DataAnnotations;

namespace _21infinity_rekrutacja_core.Models;

public partial class Training
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }

    public long OwnerId { get; set; }

    public ICollection<Enrollment>? Enrollments { get; set; }

    public ICollection<Question>? Questions { get; set; }
}
