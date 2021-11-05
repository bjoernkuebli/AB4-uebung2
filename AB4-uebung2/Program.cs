using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB4_uebung2
{
    class Program
    {
        private static bool Close = false;
        private static int ModuleSelected = 3;
        private static List<string> Modules = new List<string> { "Erweitere Suche in Strings", "Palindromtester", "App schliessen" };
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();

                switch (ModuleSelected)
                {
                    case 0:
                        SearchString();
                        ReturnToMenu();
                        break;
                    case 1:
                        PalindromtTester();
                        ReturnToMenu();
                        break;
                    case 2:
                        Close = true;
                        break;
                    case 3:
                        SelectModule();
                        break;
                    default:
                        SelectModule();
                        break;
                }

            } while (!Close);

            Environment.Exit(0);
        }
        private static void SelectModule()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Menü".PadRight(Console.BufferWidth));
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 0; i < Modules.Count(); i++)
            {
                Console.WriteLine("[{0}] {1}", i, Modules[i]);
            }

            Console.WriteLine("\nWelches Modul möchten Sie verwenden?");
            string input = Console.ReadLine();

            bool valid = int.TryParse(input, out ModuleSelected) & ModuleSelected >= 0 & ModuleSelected < Modules.Count();
            while (!valid)
            {
                RenderValidationError($"Es sind nur Zahlen zwischen 0 und {Modules.Count() - 1} erlaubt");
                Console.WriteLine("Welches Modul möchten Sie verwenden?");
                input = Console.ReadLine();
                valid = int.TryParse(input, out ModuleSelected) & ModuleSelected >= 0 & ModuleSelected < Modules.Count();
            }

        }
        private static void SearchString()
        {
            Console.WriteLine("Bitte geben sie den Eingabetext ein:");
            string text = Console.ReadLine().ToLower();

            Console.WriteLine("Bitte geben sie den Suchtext ein:");
            string needle = Console.ReadLine().ToLower();

            Console.Clear();

            // der die das der die das 
            string substring = text;

            // die

            int i = 1, before, next;
            string result;

            while (substring.IndexOf(needle) >= 0)
            {
                substring = substring.Substring(substring.IndexOf(needle) + needle.Length);

                before = text.Length - substring.Length - needle.Length;
                next = substring.IndexOf(needle);

                result = $"Treffer {i}: Anzahl Zeichen vorher: {before}, Anzahl Zeichen nachher: {substring.Length}, ";
                result += (next > 0) ? $" Anzahl Zeichen bis zum nächsten Treffer: {next}" : "keine weiteren Treffer";

                Console.WriteLine(result);
                i++;
            }
        }
        private static void PalindromtTester()
        {
            Console.WriteLine("Bitte geben sie den Eingabetext ein:");
            string input = Console.ReadLine().ToLower();
            int length = input.Length;

            Console.Clear();

            string firstHalf = input.Substring(0, length / 2);
            string lastHalf = string.Empty;

            if (length % 2 == 0)
            {
                // https://www.dotnetperls.com/reverse-string
                lastHalf = ReverseString(input.Substring(length / 2));
            }
            else
            {
                lastHalf = ReverseString(input.Substring(length / 2 + 1));
            }

            if (firstHalf == lastHalf)
            {
                Console.WriteLine("Das ist ein Palindrom\n");
            }
            else
            {
                Console.WriteLine("Das kein Palindrom\n");
            }
        }
        private static string ReverseString(string text)
        {
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
        private static void RenderValidationError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void ReturnToMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Drücken sie die Eingabetaste, um ins Menü zurückzukehren.");
            Console.ForegroundColor = ConsoleColor.White;
            ModuleSelected = 3;
            Console.ReadLine();
        }
    }
}
