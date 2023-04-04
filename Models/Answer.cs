namespace _21infinity_rekrutacja_core.Models;

public partial class Answer
{
    public long Id { get; set; }

    public long? QuestionId { get; set; }

    public long? UserId { get; set; }

    public byte[]? IsCorrect { get; set; }
}
