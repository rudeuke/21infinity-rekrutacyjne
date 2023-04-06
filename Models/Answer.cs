using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _21infinity_rekrutacja_core.Models;

public partial class Answer
{
    [Key]
    public long Id { get; set; }

    [ForeignKey(nameof(Question))]
    public long QuestionId { get; set; }

    public Question? Question { get; set; }

    [ForeignKey(nameof(UserAccount))]
    public long UserId { get; set; }

    public UserAccount? UserAccount { get; set; }

    public bool IsCorrect { get; set; }
}
