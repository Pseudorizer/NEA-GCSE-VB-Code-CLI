using System;
using System.Globalization;
using System.Threading;
using System.IO;

namespace GCSENEACodeCSharpPort
{
    class Difficulty
    {
        public static string[] Choice()
        {
            string[] subjectChoiceArray = new string[3] { "Music", "History", "Computer Science" };
            string[] difficultyChoiceArray = new string[3] { "Easy", "Medium", "Hard" };
            string[] usersChoice = new string[2];
            string space = new string(' ', 1);

            Console.WriteLine("Choose your Subject");
            Console.WriteLine("---------------------------");
            Console.WriteLine(string.Join(Environment.NewLine, subjectChoiceArray));
            Console.WriteLine(space);

            usersChoice[0] = Console.ReadLine();

            Console.WriteLine(space);
            Console.WriteLine("Choose your Difficulty");
            Console.WriteLine("---------------------------");
            Console.WriteLine(string.Join(Environment.NewLine, difficultyChoiceArray));
            Console.WriteLine(space);

            usersChoice[1] = Console.ReadLine();

            usersChoice[0] = FirstLetterToUpper(usersChoice[0]);
            usersChoice[1] = FirstLetterToUpper(usersChoice[1]);

            Console.WriteLine("Subjects Chosen, press any key to continue");
            Console.ReadKey();

            Console.Clear();

            return usersChoice;
        }

        public static string FirstLetterToUpper(string input)
        {
            if (string.IsNullOrEmpty(input)) //Look into
            {
                throw new ArgumentException("String returned null or empty");
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
        }
    }
}
