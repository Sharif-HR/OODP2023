class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        int seconds;
        while (true)
        {
            Console.WriteLine("How many seconds?");
            Console.Write(">");
            string inputSeconds = Console.ReadLine() ?? string.Empty;
            bool intConverted = int.TryParse(inputSeconds, out seconds);

            if (intConverted == false)
            {
                Console.WriteLine("error: invalid number.");
                continue;
            }
            break;
        }

        int hours = seconds / 3600;
        int minutes = (seconds % 3600) / 60;
        int secondsLeft = (seconds % 3600) % 60;

        Console.WriteLine(@$"Hours: {hours}
Minutes: {minutes}
Seconds left: {secondsLeft}");
    }
}
