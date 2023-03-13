using System.Reflection.Metadata.Ecma335;
using static System.Collections.Specialized.BitVector32;
/*
 * Author: Matthew Tan
 * Course: COMP003A
 * Purpose: Final Project, Health Program: Cancer. This is to simulate a simple medical form inquiry for Cancer patients.
 * 
 */ 
namespace COMP003A_FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SummarySeparator("General Information & Cancer Inquiry -");
            string firstName = GetNames("First");
            Console.WriteLine($"Your First Name is \"{firstName}\", is that correct? (y/n)");
            string firstConfirm = Console.ReadLine();
            while (firstConfirm.ToLower() != "y" && firstConfirm.ToLower() != "n")
            {
                Console.WriteLine("The input is invalid. Please enter y as 'yes' or n as 'no'.");
                firstConfirm = Console.ReadLine();
            }
            if (firstConfirm.ToLower() == "n")
            {
                firstName = GetNames("First");
                Console.WriteLine($"Your First Name is \"{firstName}\", is that correct? (y/n)");
                firstName = Console.ReadLine();

                while (firstConfirm.ToLower() != "y" && firstConfirm.ToLower() != "n")
                {
                    Console.WriteLine("The input is invalid. Please enter y as 'yes' or n as 'no'.");
                    firstConfirm = Console.ReadLine();
                }
            }

            string lastName = GetNames("Last");
            Console.WriteLine($"Your Last Name is \"{lastName}\", is that correct? (y/n)");
            string lastConfirm = Console.ReadLine();
            while (lastConfirm.ToLower() != "y" && lastConfirm.ToLower() != "n")
            {
                Console.WriteLine("The input is invalid. Please enter y as 'yes' or n as 'no'.");
                lastConfirm = Console.ReadLine();
            }

            if (lastConfirm.ToLower() == "n")
            {
                lastName = GetNames("Last");
                Console.WriteLine($"Your Last Name is \"{lastName}\", is that correct? (y/n)");
                lastConfirm = Console.ReadLine();

                while (lastConfirm.ToLower() != "y" && lastConfirm.ToLower() != "n")
                {
                    Console.WriteLine("The input is invalid. Please enter y as 'yes' or n as 'no'.");
                    lastConfirm = Console.ReadLine();
                }
            }
            List<string> fullName = new List<string>();
            fullName.Add(firstName);
            fullName.Add(lastName);
            DisplayFullName(fullName);

            Console.WriteLine("Please enter your birth year, must be between the year 1900 and " + DateTime.Now.Year + ":");
            int birthYear = GetBirthYear();
            Console.WriteLine($"Your birth year is {birthYear}.");
            string gender = GetGender();

            List<string> inquiries = new List<string>
            {
                "Type of Cancer: ",
                "When were you first diagnosed with this type of cancer?",
                "What are the symptoms you have been experiencing since the diagnosis?",
                "Have you undergone any treatments for this type of cancer? If yes, what treatments have you received and when did you receive them?",
                "Have you experienced any side effects from the treatments? If yes, what side effects have you experienced?",
                "Have you undergone any imaging tests or biopsies for this type of cancer? If yes, what were the results of these tests?",
                "Have you had any family history of cancer? If yes, what type of cancer and who in your family was affected?",
                "Are you currently experiencing any pain or discomfort related to this cancer? If yes, where is the pain located and how severe is it?",
                "Have you noticed any changes in your weight or appetite since the diagnosis?",
                "Are there any activities that you are unable to perform because of this cancer?",
                "What is your current state of mind regarding your cancer diagnosis, and do you have any concerns or questions for your healthcare provider?"
            };
            List<string> freeresponses = new List<string>();
            foreach (string inquiry in inquiries)
            {
                Console.WriteLine(inquiry);
                string freeresponse = Console.ReadLine();
                while (string.IsNullOrEmpty(freeresponse))
                {
                    Console.WriteLine("This response is invalid. Please try again and ensure that your responses are not empty.");
                    Console.Write(inquiry);
                    freeresponse = Console.ReadLine();
                }
                freeresponses.Add(freeresponse);
            }

            FullFormSeparator("Cancer");
            Console.WriteLine();
            DisplayNameSummary(fullName);
            Console.WriteLine();
            Console.WriteLine($"Birth Year: {birthYear}.");
            Console.WriteLine();
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine();
            FullFormSeparator("Cancer Inquiry");
            Console.WriteLine();
            for (int i = 0; i < inquiries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inquiries[i]}");
                Console.WriteLine($"Response {i + 1}. {freeresponses[i]}\n");
            }
        }
        

        static void SummarySeparator(string summary)
        {
            Console.WriteLine("".PadRight(46, '~') + $"\n{summary} Section\n" + "".PadRight(46, '~'));
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
        
        static void FullFormSeparator(string form)
        {
            Console.WriteLine("\n".PadRight(50, '~') + $"\n\t{form} -  Your Medical Profile\n" + "".PadRight(50, '~'));
        }

        static string GetNames(string nameType)
        {
            Console.WriteLine($"Please enter your {nameType} Name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrEmpty(name) || HasNumberOrSpecial(name))
            {
                Console.WriteLine($"The input is invalid as it contains null/empty/numbers/special characters. Please enter your {nameType} Name.");
                name = Console.ReadLine();
            }
            return name;
        }

        static void DisplayFullName(List<string> fullName)
        {
            fullName.Reverse();
            Console.WriteLine($"Welcome, your full name is {fullName[0]}, {fullName[1]}.");
        }
        static void DisplayNameSummary(List<string> fullName)
        {
            fullName.Reverse();
            Console.WriteLine($"Name: {fullName[0]}, {fullName[1]}.");
        }
        static int GetBirthYear()
        {
            int birthYear;
            bool validBY = int.TryParse(Console.ReadLine(), out birthYear);
            while (!validBY || birthYear < 1900 || birthYear > DateTime.Now.Year)
            {
                Console.WriteLine("The input is invalid as your Birth Year is older than 1900 or beyond the current year. Please enter a valid Birth Year.");
                validBY = int.TryParse(Console.ReadLine(), out birthYear);
            }
            return birthYear; 
        }
        static string GetGender()
        {
            Console.WriteLine("Please enter your gender (accepting M as 'male', F as 'female', O as 'other'): ");
            string gender = Console.ReadLine();
            while (string.IsNullOrEmpty(gender) || (gender != "M" && gender != "F" && gender != "O"))
            {
                Console.WriteLine("The input is invalid as it does not contain either M, F, or O. Please enter your gender: ");
                gender = Console.ReadLine();
            }
            string fullGender = DisplayFullGender(gender);
            Console.WriteLine($"Your gender is \"{gender}\" as {fullGender}.");
            return gender;
        }
        
        static string DisplayFullGender(string gender)
        {
            switch (gender.ToUpper())
            {
                case "M":
                    return "Male";
                case "F":
                    return "Female";
                case "O":
                    return "Other";
                default:
                    return "";
            }
        }
    }
}