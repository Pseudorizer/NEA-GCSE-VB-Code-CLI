using System;
using System.IO;

namespace GCSENEACodeCSharpPort
{
    class FileOps : Start
    {
        public static string GetUserDir(string inputUserName)
        {
            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());
            string dir = root + @"NeaFiles\" + inputUserName;
            string i = GetUserData(dir);

            return i;
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
                Console.WriteLine(" ");
                Login.SignIn();
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
}
