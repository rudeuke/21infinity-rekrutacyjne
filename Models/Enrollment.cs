namespace _21infinity_rekrutacja_core.Models;

public partial class Enrollment
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? TrainingId { get; set; }

    public byte[]? AvailableFrom { get; set; }

    public byte[]? AvailableTo { get; set; }
}
