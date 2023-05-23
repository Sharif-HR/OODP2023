
class Program
{
    static void Main(string[] args)
    {
        double discount = 0.1;
        int price = 55;
        double discountPrice = price  - (price * discount);

        string message;
        message = $"The discount price is {discountPrice}";
        Console.WriteLine(message);
    }
}
