﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _21infinity_rekrutacja_core.Miscellaneous;

#nullable disable

namespace _21infinity_rekrutacja_core.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.Answer", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<long>("QuestionId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("Answer", (string)null);
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.Enrollment", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<DateOnly>("AvailableFrom")
                        .HasColumnType("DateTime");

                    b.Property<DateOnly>("AvailableTo")
                        .HasColumnType("DateTime");

                    b.Property<long>("TrainingId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserId");

                    b.ToTable("Enrollment", (string)null);
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.Question", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<long>("TrainingId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.ToTable("Question", (string)null);
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.Training", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<long>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Training", (string)null);
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.UserAccount", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("User_account", (string)null);
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.Answer", b =>
                {
                    b.HasOne("_21infinity_rekrutacja_core.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_21infinity_rekrutacja_core.Models.UserAccount", "UserAccount")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.Enrollment", b =>
                {
                    b.HasOne("_21infinity_rekrutacja_core.Models.Training", "Training")
                        .WithMany("Enrollments")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_21infinity_rekrutacja_core.Models.UserAccount", "UserAccount")
                        .WithMany("Enrollments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.Question", b =>
                {
                    b.HasOne("_21infinity_rekrutacja_core.Models.Training", "Training")
                        .WithMany("Questions")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.Training", b =>
                {
                    b.HasOne("_21infinity_rekrutacja_core.Models.UserAccount", "Owner")
                        .WithMany("Trainings")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.Training", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("_21infinity_rekrutacja_core.Models.UserAccount", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Enrollments");

                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
