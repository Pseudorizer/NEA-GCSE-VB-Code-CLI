using System;

namespace GCSENEACodeCSharpPort
{
    class Login
    {
        public static void SignIn()
        {
            string userName;
            string PassInput;
            bool UserAccountCheck = false;
            bool PasswordComparisonCheck;

            do
            {
                Console.WriteLine("Please enter your username");
                userName = Console.ReadLine();
                string userDir = userName + @"\Username.txt";

                string UserCheck = FileOps.GetUserDir(userDir);

                if (UserCheck == "y")
                {
                    Console.WriteLine("User account not found");
                    UserAccountCheck = true;
                }
                else
                {
                    UserAccountCheck = false;
                }
            } while (UserAccountCheck == true);

            do
            {
                Console.WriteLine("Please enter your password");
                PassInput = Console.ReadLine();
                string passDir = userName + @"\Password.txt";

                string passRead = FileOps.GetUserDir(passDir);
                passRead.Trim();

                PasswordComparisonCheck = PasswordCheck(PassInput, passRead);
            } while (PasswordComparisonCheck == false);

            return;
        }

        static bool PasswordCheck(string userInput, string realPassword)
        {
            bool c = string.Equals(userInput, realPassword);
            switch (c)
            {
                case true:
                    Console.WriteLine("Password matches");
                    return true;
                case false:
                    Console.WriteLine("Password incorrect");
                    return false;
            }
            return false;
        }
    }
}
