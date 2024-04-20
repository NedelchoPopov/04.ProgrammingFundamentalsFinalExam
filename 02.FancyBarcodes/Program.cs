/*
3
@#FreshFisH@#
@###Brea0D@###
@##Che4s6E@##

6
@###Val1d1teM@###
@#ValidIteM@#
##InvaliDiteM##
@InvalidIteM@
@#Invalid_IteM@#
@#ValiditeM@#

 */

using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            string pattern = @"(\@[\#]+)(?<Item>[A-Z][A-Za-z0-9]{4,}[A-Z])(\@[\#]+)";

            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
                Match isMatch = Regex.Match(line, pattern);
                if (isMatch.Success)
                {
                    string digit = new string (isMatch.Groups["Item"].Value.Where(x => char.IsDigit(x)).ToArray());
                    if (digit.Length > 0 )
                    {
                        Console.WriteLine($"Product group: {digit}");
                    }
                    else
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
        
    }
}
