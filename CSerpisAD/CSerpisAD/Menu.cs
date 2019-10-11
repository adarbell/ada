using System;
using System.Collections.Generic;

namespace Serpis.Ad
{
    public class Menu
    {
        private static Dictionary<string, Action> Selection = new Dictionary<string, Action>();
        public static string Name { get; private set; }

        public static Menu Create(string name)
        {
            return new Menu();
        }

        public Menu Add(string sel, Action action)
        {
            Selection.Add(sel, action);
            return this;
        }

        public Action Show()
        {
            Console.WriteLine("------------------------------------");
            foreach (var s in Selection)
            {
                Console.WriteLine(s.Key);
            }
            Console.WriteLine("0. Salir");
            Console.WriteLine("> Selecciona: ");
            Console.WriteLine("------------------------------------");

            string userInput = Console.ReadLine();
            userInput = userInput.Substring(0, 1);
            if (userInput == "0")
                Environment.Exit(0);
            return Selection[userInput];
        }
    }
}
