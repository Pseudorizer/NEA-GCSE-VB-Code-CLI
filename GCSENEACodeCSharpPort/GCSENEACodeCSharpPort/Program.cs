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
                        break;
                    case "no":
                        userData = UserInfo();
                        string t = userData[0];
                        int j = Convert.ToInt32(userData[2]);
                        userName = t.Substring(0, 3) + j;
                        userData[4] = userName;

                        FileWrite.MainFW((string[])userData.ToArray());
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

    class FileWrite : Start
    {
        public static string GetUserDir(string inputUserName)
        {
            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());
            string dir = root + @"NeaFiles\" + inputUserName;

            return dir;
        }

        public static void FileWriter(string dir, string[] userDataArray)
        {
            string[] fileNames = new string[5] { "Name", "Password", "Age", "Year Group", "Username" };
            string userName = userDataArray[4];

            FileStream fileCreate;

            userName = userName + @"\";

            for (int i = 0; i < 5; i++)
            {
                string p = fileNames[i] + ".txt";
                fileCreate = File.Create(dir + userName + p);
                fileCreate.Close();

                StreamWriter fileStreamWriter = new StreamWriter(dir + userName + p);

                fileStreamWriter.WriteLine(userDataArray[i]);
                fileStreamWriter.Close();
            }

            return;
        }

        public static void MainFW(string[] userData)
        {
            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());
            string dir = (root + @"NeaFiles\");

            bool dirCheck = Directory.Exists(dir + userData[4] + @"\");

            if (dirCheck == true)
            {
                Console.WriteLine("User account already exists");
                return; //Change when user login is created
            }

            Directory.CreateDirectory(dir + userData[4] + @"\");
            FileWriter(dir, userData);
            return;
        }

        public static bool DirCheck(string dir)
        {
            bool check = File.Exists(dir);
            return check;
        }

        public static string GetUserData(string dir)
        {
            if (DirCheck(dir) == false)
            {
                string e = "y";
                return e;
            }
            else
            {
                string userName;
                string userNameLocation = dir;
                StreamReader ReadUserName = new StreamReader(dir);
                userName = Convert.ToString(ReadUserName.ReadLine());
                ReadUserName.Close();
                return userName;
            }
        }
    }
    class Login
    {
        public static string SignIn()
        {
            string ActualUserName;
            bool userLoop = false;

            do
            {
                Console.WriteLine("Please enter your username");
                string InputUserName = Console.ReadLine();
                InputUserName = InputUserName + @"\Username.txt";

                string UserDir = FileWrite.GetUserDir(InputUserName);
                ActualUserName = FileWrite.GetUserData(UserDir);

                if (ActualUserName == "y")
                {
                    Console.WriteLine("User account not found");
                    Console.WriteLine(" ");
                    userLoop = true;
                }
            } while (userLoop == true);

            Console.WriteLine("Please enter your password");
            string InputPassword = Console.ReadLine();
            InputPassword = InputPassword + @"\Password.txt";

            string PasswordDir = FileWrite.GetUserDir(InputPassword);
            string ActualPassword = FileWrite.GetUserData(PasswordDir);

            Console.ReadKey();

            return ActualUserName;
        }
    }
}
