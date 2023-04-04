using _21infinity_rekrutacja_core.Models;

namespace _21infinity_rekrutacja_core.Miscellaneous
{
    public static class MyHelper
    {
        public static void PrintEntity<T>(T entity)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(entity);
                Console.WriteLine($"{property.Name}: {value}");
            }
            Console.WriteLine();
        }

        public static void PrintEntities<T>(List<T> entities)
        {
            Console.WriteLine($"TABLE NAME: {typeof(T).Name}");
            foreach (var entity in entities)
            {
                PrintEntity(entity);
            }
        }
    }
}
