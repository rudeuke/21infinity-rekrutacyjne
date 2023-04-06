using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _21infinity_rekrutacja_core.Models;

public partial class Question
{
    [Key]
    public long Id { get; set; }

    [ForeignKey(nameof(Training))]
    public long TrainingId { get; set; }

    public Training? Training { get; set; }

    public ICollection<Answer>? Answers { get; set; }
}
