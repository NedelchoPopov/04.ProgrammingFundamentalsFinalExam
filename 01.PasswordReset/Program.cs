/*
Siiceercaroetavm!:?:ahsott.:i:nstupmomceqr 
TakeOdd
Cut 15 3
Substitute :: -
Substitute | ^
Done


up8rgoyg3r1atmlmpiunagt!-irs7!1fgulnnnqy
TakeOdd
Cut 18 2
Substitute ! ***
Substitute ? .!.
Done

*/
using System.Text;
using System.Text.RegularExpressions;

namespace _01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder password = new StringBuilder(Console.ReadLine());

            string input;

            while((input = Console.ReadLine()) != "Done")
            {
                string[] arguments = input.Split();

                string command = arguments[0];

                switch (command)
                {
                    case "TakeOdd":
                        string newPassword = string.Empty;
                        for (int i = 1; i < password.Length; i++)
                        {
                            if ( i % 2 != 0)
                            {
                                newPassword += password[i];
                            }
                        }
                        password.Clear();
                        password.Append(newPassword);
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int index = int.Parse(arguments[1]);
                        int lenght = int.Parse(arguments[2]);
                        if (IsValidIndex(index, lenght + index))
                        {
                            password.Remove(index, lenght);
                            Console.WriteLine(password);
                        }
                        break;
                    case "Substitute":
                        string substringA = arguments[1];
                        string substringB = arguments[2];

                        if (password.ToString().Contains(substringA))
                        {
                            password.Replace(substringA, substringB);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
            }
            Console.WriteLine($"Your password is: {password}");
        }
        private static bool IsValidIndex(int checkIndex, int endIndex)
        {
            return 0 <= checkIndex && checkIndex <= endIndex;
        }
    }
}
