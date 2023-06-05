namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool progress = true;

            while (progress)
            {
                CalculateAge();
                progress = Answer();
            }
        }
        public static bool Answer()
        {
            bool result = true;

            Console.WriteLine("Do you have a continue? (yes, no)");

            while (result)
            {
                string? answer = Console.ReadLine();
                if (answer == "no")
                {
                    Console.Clear();
                    result = false;
                }
                else if (answer == "yes")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect syntax, try again...");
                }
            }
            return result;
        }
        public static void CalculateAge()
        {
            DateTime dateTime = DateTime.Now;

            DateOnly nowDate = DateOnly.FromDateTime(dateTime);

            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("------Welcome to age calculate program------");

                Console.Write("Enter year of birth : ");
                int.TryParse(Console.ReadLine(), out int birthYear);

                Console.Write("Enter month of birth : ");
                int.TryParse(Console.ReadLine(), out int birthMonth);

                Console.Write("Enter day of birth : ");
                int.TryParse(Console.ReadLine(), out int birthDay);

                DateOnly.TryParse($"{birthDay}/{birthMonth}/{birthYear}", out DateOnly lastDate);

                int calculateYear = nowDate.Year;
                int calculateMonth = nowDate.Month;
                int calculateDay;
                if (nowDate.Day < birthDay)
                {
                    calculateDay = 31 - birthDay;
                    calculateDay += nowDate.Day;
                    calculateMonth -= 1;
                }
                else
                {
                    calculateDay = nowDate.Day - birthDay;
                }
                if (calculateMonth < birthMonth)
                {
                    calculateMonth = 12 - birthMonth;
                    calculateMonth += nowDate.Month;
                    calculateYear -= 1;
                }
                else
                {
                    calculateMonth = nowDate.Month - birthMonth;
                }

                if (calculateMonth < 0)
                {
                    calculateMonth *= -1;
                }
                if (calculateDay < 0)
                {
                    calculateDay *= -1;
                    calculateDay += nowDate.Day;
                }
                calculateYear -= birthYear;


                Console.WriteLine($"The person was born {calculateMonth-1} months {calculateDay} days {calculateYear} years ago.\n");

            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Please enter valid value...");
                CalculateAge();
            }
        }
    }
}