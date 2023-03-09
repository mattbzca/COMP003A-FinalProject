using static System.Collections.Specialized.BitVector32;
/*
 * Author: Matthew Tan
 * Course: COMP003A
 * Purpose: Final Project, Health Program
 * 
 */ 
namespace COMP003A_FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SummarySeparator("Name -");
            Console.WriteLine("Please enter your First Name: ");
            string firstName = Convert.ToString(Console.ReadLine());
            while (string.IsNullOrEmpty(firstName) || HasNumberOrSpecial(firstName))
            {
                Console.WriteLine("The input is invalid as it contains null/empty/numbers/special characters. Please enter your First Name.");
                firstName = Console.ReadLine();
            }
            Console.WriteLine($"Your First Name is \"{firstName}\", is that correct?");
        }

        static void SummarySeparator(string summary)
        {
            Console.WriteLine("".PadRight(50, '~') + $"\n\t\t{summary} Section\n" + "".PadRight(50, '~'));
        }
        static bool HasNumberOrSpecial(string lettercheck)
        {
            foreach (char c in lettercheck)
            {
                if (!char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}