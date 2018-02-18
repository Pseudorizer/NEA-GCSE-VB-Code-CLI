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
                Console.WriteLine("Do you have an account? Yes or No?"); //Ask user if they have an account
                string AccountCheck = Console.ReadLine(); //Save response
                AccountCheck.ToLower();

                Console.WriteLine(space);

                switch (AccountCheck) //Switch statement to check response
                {
                    case "yes":
                        Login.SignIn(); //Move to method SignIn in class Login
                        l = false; //Escape do loop
                        break;
                    case "no":
                        userData = UserInfo(); //Call method UserInfo to get user info, store return data in an array
                        string t = userData[0]; //Get username from userData array
                        int j = Convert.ToInt32(userData[2]); //Get age from userData array
                        userName = t.Substring(0, 3) + j; //Combine first 3 letters of the username and the age into one string
                        userData[4] = userName; //Put userName into the array
                        Console.WriteLine("Your username is {0}", userData[4]); //Tell the user their username

                        FileOps.MainFW((string[])userData.ToArray()); //Call class FileOps passing userData along
                        l = false;
                        break;
                    default: //If the users reponse didn't equal yes or no
                        Console.WriteLine("Error incorrect response");
                        Console.WriteLine(space);
                        l = true;
                        break;
                }
            } while (l == true);

            Console.WriteLine("Login successful");

            Console.ReadKey();
        }

        static string[] UserInfo()
        {
            string[] writeIndex = new string[4] { "name", "password", "age", "year group" }; //Store questions in an array to call in for loop
            string[] userData = new string[5]; //For storing user responses

            for (int i = 0; i < 4; i++) //Goes until i = 4, add 1 to i every loop
            {
                Console.WriteLine("Please enter your {0}", writeIndex[i]);
                userData[i] = Console.ReadLine(); //Store response to userData array
            }

            return userData;
        }
    }
}
