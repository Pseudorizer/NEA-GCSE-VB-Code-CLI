using System;
using System.IO;

namespace GCSENEACodeCSharpPort
{
    class FileOps : Start
    {
        public static string GetUserDir(string inputUserName)
        {
            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());
            string dir = root + @"NeaFiles\" + inputUserName; //Creates a string for the directory location
            string i = GetUserData(dir); 

            return i; //Returns value
        }

        public static void FileWriter(string dir, string[] userDataArray)
        {
            string[] fileNames = new string[5] { "Name", "Password", "Age", "Year Group", "Username" }; //Array for passing file names inside for loop
            string userName = userDataArray[4]; //Used to create users directory

            FileStream fileCreate;

            userName = userName + @"\";

            for (int i = 0; i < 5; i++) //Goes until i = 5
            {
                string p = fileNames[i] + ".txt"; //Creates full filenames for each loop so the file it's writing to is automatic
                fileCreate = File.Create(dir + userName + p); //Creates the files in the correct directory
                fileCreate.Close();

                StreamWriter fileStreamWriter = new StreamWriter(dir + userName + p); //Open fileStreamWriter in the current user directory

                fileStreamWriter.WriteLine(userDataArray[i]); //Write the data the user entered to the correct file
                fileStreamWriter.Close();
            }

            return;
        }

        public static void MainFW(string[] userData)
        {
            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());
            string dir = (root + @"NeaFiles\");

            bool dirCheck = Directory.Exists(dir + userData[4] + @"\"); //Makes sure the user account doesn't already exist

            if (dirCheck == true) //If it does move them along to Login.SignIn()
            {
                Console.WriteLine("User account already exists");
                Console.WriteLine(" ");
                Login.SignIn();
            }

            Directory.CreateDirectory(dir + userData[4] + @"\"); //Create directory for user
            FileWriter(dir, userData); 
            Login.SignIn();
        }

        public static bool DirCheck(string dir)
        {
            bool check = File.Exists(dir);
            return check;
        }

        public static string GetUserData(string dir)
        {
            if (DirCheck(dir) == false) //Checks if the location exists
            {
                string e = "y"; //If not return e
                return e;
            }
            else //If it does exist
            {
                string userName;
                StreamReader ReadUserName = new StreamReader(dir); //Opens the text from dir
                userName = Convert.ToString(ReadUserName.ReadLine()); //Converts data read by ReadUserName into string and stores it
                ReadUserName.Close();
                return userName;
            }
        }
    }
}
