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

        public static void Z2()
        {
            Console.WriteLine("Zadanie 2:");

            var users = Utilities.GetZ2Users();
            foreach (var user in users)
            {
                Console.WriteLine(user.UserName);
            }
        }
    }
}
