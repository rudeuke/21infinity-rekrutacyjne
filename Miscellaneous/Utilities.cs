using _21infinity_rekrutacja_core.Models;

namespace _21infinity_rekrutacja_core.Miscellaneous
{
    public static class Utilities
    {
        public static List<UserAccount> GetZ1Users()
        {
            using (var db = new DataContext())
            {
                var excludedTrainingNames = new List<string> { "BHP", "Kurs zarządzania", "Podstawy Excela" };

                var trainingsExcluded = db.Trainings.Where(t => excludedTrainingNames.Contains(t.Name));

                var excludedUsers = db.Enrollments
                    .Join(trainingsExcluded, Enrollment => Enrollment.TrainingId, Training => Training.Id, (Enrollment, Training) => new { Enrollment, Training })
                    .Join(db.UserAccounts, join1 => join1.Enrollment.UserId, UserAccount => UserAccount.Id, (join1, UserAccount) => new { UserAccount })
                    .Select(u => u.UserAccount);

                var users = db.UserAccounts.Except(excludedUsers);

                return users.ToList();
            }
        }
    }
}
