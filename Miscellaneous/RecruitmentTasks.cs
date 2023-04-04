namespace _21infinity_rekrutacja_core.Miscellaneous
{
    public static class RecruitmentTasks
    {
        public static void Z1()
        {
            Console.WriteLine("Zadanie 1:");

            var users = Utilities.GetZ1Users();
            foreach (var user in users)
            {
                Console.WriteLine(user.UserName);
            }
        }
    }
}
