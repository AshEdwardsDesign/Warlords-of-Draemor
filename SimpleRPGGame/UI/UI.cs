using System;

namespace WarlordsOfDraemor
{
    public static class UI
    {
        /// <summary>
        /// Displays a string of text formatted as a title. 
        /// </summary>
        /// <param name="text">The text you would like to display in the title.</param>
        /// <param name="clear">Should the console window be cleared? Defaults to true.</param>
        public static void DisplayTitle(string text, bool clear = true)
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

        public static void DisplayInputText(string text, bool inline = false)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (inline) Console.Write(text);
            else Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void DisplaySuccessText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text.ToUpper());
            Console.ResetColor();
        }

        public static void DisplayWarningText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text.ToUpper());
            Console.ResetColor();
        }

        public static void DisplayNoticeText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
