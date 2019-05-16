using System;

namespace WarlordsOfDraemor
{
    public static class UI
    {
        public static void DisplayTitle(string text, bool clear = false)
        {
            if (clear) Console.Clear();
            string seperator = new string('#', text.Length);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(seperator);
            Console.WriteLine($"{text.ToUpper()}");
            Console.WriteLine(seperator);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void DisplaySubTitle(string text)
        {
            string seperator = new string('-', text.Length);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{text.ToUpper()}");
            Console.WriteLine(seperator);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
