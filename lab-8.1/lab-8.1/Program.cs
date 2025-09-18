delegate System.Int32 simpleDelegate(System.Int32 i);
class SimpleLambda
{
    static void Main(string[] args)
    {
        simpleDelegate Square = x => x * x;
        int squareRes = Square(10);
        Console.WriteLine("Результат: {0}", squareRes);
        Console.ReadLine();
    }
}