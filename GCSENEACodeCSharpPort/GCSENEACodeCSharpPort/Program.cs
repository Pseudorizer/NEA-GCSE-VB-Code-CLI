using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GCSENEACodeCSharpPort
{
    class Start
    {
        public static List<string> UserInfo()
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

                Console.WriteLine(space);

                switch (AccountCheck)
                {
                    case "yes":

                        break;
                    case "no":
                        userData = UserInfo();
                        string t = userData[0];
                        int j = Convert.ToInt32(userData[2]);
                        userName = t.Substring(0, 3) + j;
                        bool test = FileWrite.DirExist(userName);
                        if (test == false)
                        {
                            Console.WriteLine("1");
                        }
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
    }

    class FileWrite: Start
    {
        public static bool DirExist(string path)
        {
            return (Directory.Exists(path));
        }

        private void FS(string dir, string userName)
        {
            string[] fileNames = new string[5] { "Name", "Password", "Age", "Year Group", "Username" };

            FileStream fileCreate;

            userName = userName + @"\";

            for (int i = 0; i < 5; i++)
            {
                string p = fileNames[i] + ".txt";
                fileCreate = File.Create(dir + userName + p);
            }
        }

        public static bool DirCheck(string userName)
        {
            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());
            string dir = (root + @"NeaFiles\");

            bool dirCheck = DirExist(dir);

            if (dirCheck == true)
            {

            }
            else if (dirCheck == false)
            {
                Directory.CreateDirectory(dir);

                Directory.CreateDirectory(dir + userName);
               
            }

            dirCheck = DirExist(dir);

            return dirCheck;
        }
    }
}
