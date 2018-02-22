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
            bool subjectLoop;
            bool difficultyLoop;

            do
            {
                Console.WriteLine("Choose your Subject");
                Console.WriteLine("---------------------------");
                Console.WriteLine(string.Join(Environment.NewLine, subjectChoiceArray));
                Console.WriteLine(space);

                usersChoice[0] = Console.ReadLine();
                usersChoice[0] = FirstLetterToUpper(usersChoice[0]);

                subjectLoop = CheckIfInputIsValid(subjectChoiceArray, usersChoice[0]);
            } while (subjectLoop == true);

            do
            {
                Console.WriteLine(space);
                Console.WriteLine("Choose your Difficulty");
                Console.WriteLine("---------------------------");
                Console.WriteLine(string.Join(Environment.NewLine, difficultyChoiceArray));
                Console.WriteLine(space);

                usersChoice[1] = Console.ReadLine();
                usersChoice[1] = FirstLetterToUpper(usersChoice[1]);

                difficultyLoop = CheckIfInputIsValid(difficultyChoiceArray, usersChoice[1]);
            } while (difficultyLoop == true);

            Console.Clear();
            Console.WriteLine("Subjects Chosen, press any key to continue");
            Console.ReadKey();

            Console.Clear();

            return usersChoice;
        }

        static bool CheckIfInputIsValid(string[] originalArray, string usersInput)
        {
            int k = Array.IndexOf(originalArray, usersInput);

            if (k > -1)
            {
                return false;
            }
            else if (k == -1)
            {
                Console.Clear();
                Console.WriteLine("You did not enter a correct value");
                Console.WriteLine("");
                return true;
            }

            return false; //Find out how to do this correctly
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
