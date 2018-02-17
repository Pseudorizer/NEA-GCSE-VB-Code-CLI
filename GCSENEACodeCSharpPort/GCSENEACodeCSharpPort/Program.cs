using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCSENEACodeCSharpPort
{
    class Start
    {
        static List<string> UserInfo()
        {
            string[] writeIndex = new string[4] { "name", "password", "age", "year group" };
            List<string> savedValues = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Please enter your {0}", writeIndex[i]);
                savedValues.Add(Console.ReadLine());
            }

            return savedValues;
        }

        static void Main()
        {
            string space = new string(' ', 1);
            bool l = false;
            string userName;
            List<string> userData;

            do {
                Console.WriteLine("Do you have an account? Yes or No?");
                string AccountCheck = Console.ReadLine();
                AccountCheck.ToLower();

                if (AccountCheck == "yes")
                {
                    
                }
                else if (AccountCheck == "no")
                {
                    userData = UserInfo();
                    string t = userData[0];
                    int j = Convert.ToInt32(userData[1]);
                    userName = t.Substring(0, 3) + j;
                }
                else
                {
                    Console.WriteLine("Error incorrect response");
                    Console.WriteLine(space);
                    l = true;
                }
            } while (l == true);

         Console.ReadKey();
        }
    }
}
