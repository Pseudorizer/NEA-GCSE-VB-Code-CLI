using System;

namespace GCSENEACodeCSharpPort
{
    class Login
    {
        public static void SignIn()
        {
            string userName;
            string PassInput;
            bool UserAccountCheck;
            bool PasswordComparisonCheck;
            string space = new string(' ', 1);

            Console.WriteLine(space);
            Console.WriteLine("Login");
            Console.WriteLine("---------------------------");

            do
            {
                Console.WriteLine(space);
                Console.WriteLine("Please enter your username");
                userName = Console.ReadLine();
                string userDir = userName + @"\Username.txt";

                string UserCheck = FileOps.GetUserDir(userDir);

                if (UserCheck == "False")
                {
                    UserCheck.ToLower();
                    UserAccountCheck = Convert.ToBoolean(UserCheck);
                }
                else
                {
                    UserAccountCheck = StringCheck(userName, UserCheck);
                }

            } while (UserAccountCheck == false);

            do
            {
                Console.WriteLine(space);
                Console.WriteLine("Please enter your password");
                PassInput = Console.ReadLine();
                string passDir = userName + @"\Password.txt";

                string passRead = FileOps.GetUserDir(passDir);
                passRead.Trim();

                PasswordComparisonCheck = StringCheck(PassInput, passRead);
            } while (PasswordComparisonCheck == false);

            Console.WriteLine(space);
            Console.WriteLine("Login successful, press any key to continue");

            Console.Clear();

            string[] a = new string[2];
            a = Difficulty.Choice();

            Questions.QuestionsMain(a);

            Console.ReadKey();
        }

        static bool StringCheck(string Input, string ToCompare)
        {
            bool c = string.Equals(Input, ToCompare);
            switch (c)
            {
                case true:
                    Console.WriteLine(" ");
                    Console.WriteLine("Success");
                    return true;
                case false:
                    Console.WriteLine(" ");
                    Console.WriteLine("Incorrect");
                    return false;
            }
            Console.WriteLine("Process escaped switch @line 68, Login.cs");
            return false;
        }
    }
}
