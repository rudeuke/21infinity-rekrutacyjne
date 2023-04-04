using _21infinity_rekrutacja_core.Models;
using Microsoft.EntityFrameworkCore;

namespace _21infinity_rekrutacja_core.Miscellaneous;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Training> Trainings { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=D:/SQLiteStudio/_db/Data.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.ToTable("Answer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsCorrect).HasColumnType("bit");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("Enrollment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AvailableFrom).HasColumnType("DateTime");
            entity.Property(e => e.AvailableTo).HasColumnType("DateTime");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.ToTable("Training");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasColumnType("varchar(40)");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.ToTable("User_account");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.UserName).HasColumnType("varchar(20)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
