using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSENEACodeCSharpPort
{
    class Start
    {
        static void Main()
        {
            string space = new string(' ', 1);
            bool l = false;
            string userName;
            string[] userData = new string[5];

            do
            {
                Console.WriteLine("Do you have an account? Yes or No?");
                string AccountCheck = Console.ReadLine();
                AccountCheck.ToLower();

                Console.WriteLine(space);

                switch (AccountCheck)
                {
                    case "yes":
                        Login.SignIn();
                        Console.WriteLine("done");
                        break;
                    case "no":
                        userData = UserInfo();
                        string t = userData[0];
                        int j = Convert.ToInt32(userData[2]);
                        userName = t.Substring(0, 3) + j;
                        userData[4] = userName;

                        FileOps.MainFW((string[])userData.ToArray());
                        Login.SignIn();
                        break;
                    default:
                        Console.WriteLine("Error incorrect response");
                        Console.WriteLine(space);
                        l = true;
                        break;
                }
            } while (l == true);

            Console.ReadKey();
        }

        static string[] UserInfo()
        {
            string[] writeIndex = new string[4] { "name", "password", "age", "year group" };
            string[] userData = new string[5];

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Please enter your {0}", writeIndex[i]);
                userData[i] = Console.ReadLine();
            }

            return userData;
        }
    }
}
