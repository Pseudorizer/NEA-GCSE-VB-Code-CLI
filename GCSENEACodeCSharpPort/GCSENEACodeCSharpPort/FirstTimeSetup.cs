using System;
using System.IO;

namespace GCSENEACodeCSharpPort
{
    class FirstTimeSetup
    {
        public static void MainFTS()
        {
            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());

            Console.Clear();
            Console.WriteLine("You will now setup your user data/questions location.");
            Console.WriteLine("It will be saved on your current drive that the executable is running on");

            Console.WriteLine("Please enter the name you'd like for your user data/questions folder");
            string userFolderName = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Creating Directories...");
            Console.WriteLine("-------------------------");

            string[] subDirs = new string[3] { @"\Easy", @"\Medium", @"\Hard" };
            string[] dirs = new string[3] { @"\Computer Science", @"\History", @"\Music" };

            string questionDirs = (root + userFolderName + @"\Questions");

            for (int i = 0; i < 3; i++)
            {
                foreach (string subDir in subDirs)
                {
                    Directory.CreateDirectory(questionDirs + dirs[i] + subDir);
                }
            }

            string userFolderLocation = root + userFolderName;

            string permDir = root + "NeaFolderData";
            Directory.CreateDirectory(permDir);

            File.Create(permDir + @"\path.txt").Close();

            StreamWriter writer = new StreamWriter(permDir + @"\path.txt");
            writer.WriteLine(userFolderLocation);
            writer.Close();

            Console.WriteLine("Done. Created {0} and {1}. Press any key to continue", userFolderLocation, permDir);
            Console.ReadKey();

            Console.Clear();

            Start.Main();
        }
    }
}
