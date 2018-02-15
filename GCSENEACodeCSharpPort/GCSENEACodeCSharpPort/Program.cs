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
            int e = 0;

            do {
                Console.WriteLine("Do you have an account? Yes or No?");
                string name = Console.ReadLine();
                name.ToLower();

                if (name == "yes")
                {
                    Console.WriteLine("yes test");
                }
                else if (name == "no")
                {
                    Console.WriteLine("No test");
                }
                else
                {
                    Console.WriteLine("Error incorrect response");
                    Console.WriteLine(space);
                    e++;
                }
            } while (e == 1);

         Console.ReadKey();
        }
        public void UserInfo()
        {

        }
    }
    class FileRW
    {

    }
}
