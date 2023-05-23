internal class Program
{
    static void Main(string[] args)
    {
        // Console.Clear();
        int totalPoints = 0;

        Console.WriteLine("Answer the following MCQs");

        List<string> answers1 = new List<string>() { "bool", "int", "var", "string" };
        int q1 = Question("Which of the following is NOT a valid type in C#?", answers1, "c", 0);
        totalPoints += q1;


        List<string> answers2 = new() { "x will be 1.23", "x will be 1", "x will be 1.0", "you will get a compiler error" };
        int q2 = Question($"What happens if you execute the following line C#?\nint x = 1.23;", answers2, "d");
        totalPoints += q2;

        List<string> answers3 = new() { "int i = (int)d;", "int i = int(d)", "int i = 0 + d", "int i = Convert.ToInt32(d)" };
        List<string> correctAnswers = new() { "a", "d" };
        int q3 = QuestionMultipleAnswers(
            "Consider the following line:\ndouble d = 1.23;\nWhat are TWO ways to convert variable d to an int?",
            answers3,
            correctAnswers
        );
        totalPoints += q3;


        if (totalPoints == 3)
        {
            Console.WriteLine($"Your score: {totalPoints} out of 3. Well done!");
        }
        else
        {
            Console.WriteLine($"Your score: {totalPoints} out of 3.");
        }

    }


    private static string validInput()
    {
        Console.Write(">");
        List<string> validInputs = new() { "a", "b", "c", "d" };

        ConsoleKeyInfo keyInfo = Console.ReadKey();
        char letter = keyInfo.KeyChar;
        string userInput = letter.ToString();

        if (!validInputs.Contains(userInput.ToLower()) || String.IsNullOrWhiteSpace(userInput))
        {
            return "x";
        }
        return userInput;
    }


    private static List<string> validInputs(List<string> message, int inputsAmount)
    {
        List<string> userInputs = new List<string>();

        for (int i = 0; i < inputsAmount; i++)
        {
            Console.WriteLine(message[i]);
            Console.Write(">");
            List<string> validInputs = new() { "a", "b", "c", "d" };

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char letter = keyInfo.KeyChar;
            string userInput = letter.ToString();
            Console.WriteLine("");

            if (!validInputs.Contains(userInput.ToLower()) || String.IsNullOrWhiteSpace(userInput))
            {
                userInputs.Add("x");
                continue;
            }

            userInputs.Add(userInput);
        }


        return userInputs;
    }


    private static Dictionary<string, string> ListToAnswers(List<string> answers)
    {
        var options = new Dictionary<string, string>();

        options["a"] = answers[0];
        options["b"] = answers[1];
        options["c"] = answers[2];
        options["d"] = answers[3];

        return options;
    }


    private static void PrintEnters(int entersAmount = 2)
    {
        for (int i = 0; i < entersAmount; i++)
        {
            Console.WriteLine("");
        }
    }


    private static int Question(string question, List<string> answers, string goodAnswer, int enters = 2)
    {
        PrintEnters(enters);
        Console.WriteLine(question);
        var answersDict = ListToAnswers(answers);

        foreach (KeyValuePair<string, string> item in answersDict)
        {
            string option = item.Key.ToUpper();
            string answer = item.Value;
            Console.WriteLine($"{option}: {answer}");
        }

        string userInput = validInput();


        if (userInput == "x")
        {
            return 0;
        }

        if (userInput != goodAnswer)
        {
            return 0;
        }

        return 1;
    }

    private static int QuestionMultipleAnswers(string question, List<string> answers, List<string> goodAnswers, int enters = 2)
    {
        PrintEnters();
        Console.WriteLine(question);
        var answersDict = ListToAnswers(answers);

        foreach (KeyValuePair<string, string> item in answersDict)
        {
            string option = item.Key.ToUpper();
            string answer = item.Value;
            Console.WriteLine($"{option}: {answer}");
        }

        List<string> messages = new List<string>() { "Your first answer:", "Your second answer:" };
        var userInputs = validInputs(messages, messages.Count);

        foreach (string userInput in userInputs)
        {
            if (userInput == "x")
            {
                return 0;
            }
        }


        for (int i = 0; i < userInputs.Count(); i++)
        {
            if (goodAnswers[i] != userInputs[i])
            {
                return 0;
            }
        }

        return 1;
    }
}
