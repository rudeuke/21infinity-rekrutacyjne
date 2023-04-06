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

                var trainingsExcluded = db.Trainings.Where(t => excludedTrainingNames.Contains(t.Name));

                var excludedUsers = db.UserAccounts.Where(u => u.Enrollments.Any(e => trainingsExcluded.Contains(e.Training)));

                var users = db.UserAccounts.Except(excludedUsers);

                return users.ToList();
            }
        }
    }
}
