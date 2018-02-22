using System;
using System.IO;
using System.Linq;

namespace GCSENEACodeCSharpPort
{
    class Start
    {
        static void PostFirstTimeSetupFlow()
        {
            string[] userData = new string[5];

            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());
            DirectoryInfo countFolders = new DirectoryInfo(FileOps.GetCustomUserFolder(root));

            int postFirstTimeSetupCheck = countFolders.EnumerateDirectories().Count();

            if (postFirstTimeSetupCheck == 1)
            {
                Console.WriteLine("No user accounts detected, press any key to continue");
                Console.ReadKey();
                userData = UserInfo();

                userData[4] = userData[0].Substring(0, 3) + userData[2];
                Console.WriteLine("Your username is {0}", userData[4]);

                FileOps.MainFW(userData.ToArray());
            }

            return;
        }

        public static void Main()
        {
            string space = new string(' ', 1);
            bool do2 = false;
            string[] userData = new string[5];

            Exceptions.NeaFolderDataCheck();

            Exceptions.NoUserFolderCatch();

            PostFirstTimeSetupFlow();

            do
            {
                Console.WriteLine("Do you have an account? Yes or No?"); //Ask user if they have an account
                string AccountCheck = Console.ReadLine(); //Save response
                AccountCheck.ToLower();

                Console.WriteLine(space);

                switch (AccountCheck) //Switch statement to check response
                {
                    case "yes":
                        Console.Clear();
                        Login.SignIn(); //Move to method SignIn in class Login
                        do2 = false; //Escape do loop
                        break;
                    case "no":
                        userData = UserInfo(); //Call method UserInfo to get user info, store return data in an array
                        userData[4] = userData[0].Substring(0, 3) + userData[2]; //Create userName and put it into the array
                        Console.WriteLine("Your username is {0}", userData[4]);

                        FileOps.MainFW(userData.ToArray()); //Call FileOps.MainFW passing userData along
                        do2 = false;
                        break;
                    default: //If the users reponse didn't equal yes or no
                        Console.WriteLine("Error incorrect response");
                        Console.WriteLine(space);
                        do2 = true;
                        break;
                }
            } while (do2 == true);

            Console.ReadKey();
        }

        public static string[] UserInfo()
        {
            string[] writeIndex = new string[4] { "name", "password", "age", "year group" }; //Store questions in an array to call in for loop
            string[] userData = new string[5]; //For storing user responses
            bool loop = false;

            Console.Clear();

            Console.WriteLine("Account Creation");
            Console.WriteLine("---------------------------");
            Console.WriteLine("");

            do
            {
                for (int i = 0; i < 4; i++) //Goes until i = 4, add 1 to i every loop
                {
                    Console.WriteLine("Please enter your {0}", writeIndex[i]);
                    userData[i] = Console.ReadLine(); //Store response to userData array
                }

                Console.Clear();

                bool letterTest = UserDataLetterCheck(userData);

                if (letterTest == true)
                {
                    Console.WriteLine("Do not enter characters for your age!");
                    Console.WriteLine(" ");
                    loop = true;
                }
                else if (letterTest == false)
                {
                    return userData;
                }
            } while (loop == true);
            return null; //Find out what you're supposed to do in this situation
        }

        public static bool UserDataLetterCheck(string[] array)
        {
            bool checkForIntegers = array[2].Any(char.IsLetter);
            return checkForIntegers;
        }
    }
}
