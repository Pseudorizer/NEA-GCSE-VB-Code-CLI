using System;
using System.IO;
using System.Linq;

namespace GCSENEACodeCSharpPort
{
    class Exceptions
    {
        public static void NoUserFolderCatch()
        {
            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());
            string r = FileOps.GetCustomUserFolder(root);
            if (Directory.Exists(r) == false)
            {
                Console.WriteLine("User account folder is missing, it will now be recreated");
                string p = root + @"NeaFolderData\";
                DirectoryInfo d = new DirectoryInfo(p);
                d.Delete(true);
                Console.WriteLine("");
                Console.WriteLine("You will now run through the first time setup again, press any key to continue");
                Console.ReadKey();
                FirstTimeSetup.MainFTS();
            }
            return;
        }

        public static void NeaFolderDataCheck()
        {
            bool do1 = false;
            string root = Path.GetPathRoot(Directory.GetCurrentDirectory());

            if (!Directory.Exists(root + "NeaFolderData"))
            {
                do
                {
                    Console.WriteLine("Is this your first time running the software? Yes or No?");
                    string firstRunAnswer = Console.ReadLine();
                    firstRunAnswer.ToLower();

                    if (firstRunAnswer == "yes")
                    {
                        Console.WriteLine("Running first time setup...");
                        do1 = false;
                        FirstTimeSetup.MainFTS();
                    }
                    else if (firstRunAnswer == "no")
                    {
                        Console.WriteLine("Error: NeaFolderData not found");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter yes or no");
                        Console.WriteLine(" ");
                        do1 = true;
                    }
                } while (do1 == true);
            }
            return;
        }
    }
}
