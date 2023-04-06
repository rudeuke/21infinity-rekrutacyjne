using System.ComponentModel.DataAnnotations;

namespace _21infinity_rekrutacja_core.Models;

public partial class UserAccount
{
    [Key]
    public long Id { get; set; }

    public string UserName { get; set; }

    public ICollection<Answer>? Answers { get; set; }

    public ICollection<Enrollment>? Enrollments { get; set; }
}
