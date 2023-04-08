using _21infinity_rekrutacja_core.Models;

namespace _21infinity_rekrutacja_core.Miscellaneous
{
    public static class Utilities
    {
        public static List<UserAccount> GetZ1Users()
        {
            using (var db = new DatabaseContext())
            {
                var excludedTrainingNames = new[] { "BHP", "Kurs zarządzania", "Podstawy Excela" };

                return db.UserAccounts
                    .Where(u =>
                        !u.Enrollments.Any(e => excludedTrainingNames.Contains(e.Training.Name)))
                    .ToList();
            }
        }

        public static List<UserAccount> GetZ2Users()
        {
            using (var db = new DatabaseContext())
            {
                var ownerUserName = "Jan Kowalski";

                return db.UserAccounts
                    .Where(u =>
                        u.Answers.Any(a => a.Question.Training.Owner.UserName == ownerUserName)
                            && (double)u.Answers.Count(a => a.IsCorrect && a.Question.Training.Owner.UserName == ownerUserName) /
                            u.Answers.Count(a => a.Question.Training.Owner.UserName == ownerUserName) >= 0.5)
                    .ToList();
            }
        }

        public static List<Training> GetZ3Trainings()
        {
            using (var db = new DatabaseContext())
            {
                return db.Trainings
                    .Where(t =>
                        !t.Enrollments.Any(e => e.AvailableTo > DateTime.Now)
                        && !t.Questions.Any(q => q.Answers.Any(a => a.IsCorrect)))
                    .ToList();
            }
        }
    }
}
