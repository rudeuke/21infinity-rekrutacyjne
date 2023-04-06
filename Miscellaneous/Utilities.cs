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

        public static List<UserAccount> GetZ2Users()
        {
            using (var db = new DatabaseContext())
            {
                var questionsAddedByJK = db.Questions.Where(q => q.Training.Owner.UserName == "Jan Kowalski");

                var answersToJKQuestions = db.Answers.Where(a => questionsAddedByJK.Contains(a.Question));

                var userAnswers = answersToJKQuestions.GroupBy(a => a.UserAccount).Select(a => new { User = a.Key, AllAnswers = a.Count(), CorrectAnswers = a.Where(a => a.IsCorrect).Count() });

                var usersOver50p = userAnswers.Where(u => (double)u.CorrectAnswers / u.AllAnswers >= 0.5).Select(a => new { a.User, a.AllAnswers, a.CorrectAnswers });
                
                var users=db.UserAccounts.Where(u => usersOver50p.Any(uo => uo.User == u));

                return users.ToList();
            }
        }
    }
}
