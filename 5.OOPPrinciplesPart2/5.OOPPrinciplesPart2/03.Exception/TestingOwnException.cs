namespace ExceptionClass
{
    using System;
    using System.Globalization;

    class TestingOwnException
    {
        static void Main()
        {
            try
            {
                int number = ReadInteger(1, 100);
                Console.WriteLine("Your number is: " + number);
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine("{0}\nRange[{1}; {2}].", ex.Message, ex.Start, ex.End);
            }

            try
            {
                DateTime date = ReadInteger(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                Console.WriteLine("Your date is: " + date.ToString("dd.MM.yyyy"));
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine("{0}\nRange[{1}; {2}]!", ex.Message, ex.Start.ToString("dd.MM.yyyy"), ex.End.ToString("dd.MM.yyyy"));
            }
        }

        public static int ReadInteger(int start, int end)
        {
            int number;

            do
            {
                Console.WriteLine("Insert number in interval [{0}; {1}]:", start, end);
            } while (!int.TryParse(Console.ReadLine(), out number));

            if (number < start || number > end)
            {
                throw new InvalidRangeException<int>(start, end, "Value is out of range!");
            }
            else
            {
                return number;
            }
        }
        public static DateTime ReadInteger(DateTime start, DateTime end)
        {
            DateTime date;

            do
            {
                Console.WriteLine("Insert date (format: day.month.year) in interval [{0}; {1}]:", start.ToString("dd.MM.yyyy"), end.ToString("dd.MM.yyyy"));
            } while (!DateTime.TryParseExact(Console.ReadLine(), "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date));

            if (date < start || date > end)
            {
                throw new InvalidRangeException<DateTime>(start, end, "Value is out of range!");
            }
            else
            {
                return date;
            }
        }
    }
}
