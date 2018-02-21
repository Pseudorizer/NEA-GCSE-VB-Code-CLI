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

            string questionDirs = (root + userFolderName + @"\Questions");

            Directory.CreateDirectory(questionDirs + @"\Computer Science");
            Directory.CreateDirectory(questionDirs + @"\Computer Science\Easy");
            Directory.CreateDirectory(questionDirs + @"\Computer Science\Medium");
            Directory.CreateDirectory(questionDirs + @"\Computer Science\Hard");

            Directory.CreateDirectory(questionDirs + @"\History");
            Directory.CreateDirectory(questionDirs + @"\History\Easy");
            Directory.CreateDirectory(questionDirs + @"\History\Medium");
            Directory.CreateDirectory(questionDirs + @"\History\Hard");

            Directory.CreateDirectory(questionDirs + @"\Music");
            Directory.CreateDirectory(questionDirs + @"\Music\Easy");
            Directory.CreateDirectory(questionDirs + @"\Music\Medium");
            Directory.CreateDirectory(questionDirs + @"\Music\Hard");

            string userFolderLocation = root + userFolderName + @"\";

            string permDir = root + "NeaFolderData";
            Directory.CreateDirectory(permDir);

            File.Create(permDir + @"\path.txt").Close();

            StreamWriter writer = new StreamWriter(permDir + @"\path.txt");
            writer.WriteLine(userFolderLocation);
            writer.Close();

            Console.WriteLine("Done. Created {0} and {1}. Press any key to continue to account creation", userFolderLocation, permDir);
            Console.ReadKey();

            Console.Clear();

            Start.Main();
        }
    }
}
