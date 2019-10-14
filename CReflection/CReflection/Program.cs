using System;

namespace CReflection
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Categoria categoria = new Categoria(5, "Cat 5");
            show(categoria, "Nombre");
        }

        private static void show(object obj, params string[] propertyNames)
        {
            foreach (string propertyName in propertyNames)
                Console.WriteLine("propertyName = {0}\nValue = {1}",
                propertyName, obj.GetType().GetProperty(propertyName).GetValue(obj));
        }
    }
}
