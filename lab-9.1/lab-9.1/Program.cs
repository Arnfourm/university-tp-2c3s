using System;
using System.Threading;
class ThreadSafe
{
    static int maxi = 100;
    static int i;
    static object locker = new object();
    static void Main()
    {
        new Thread(GoA).Start();
        GoB();
        Console.ReadLine();
    }
    static void GoA()
    {
        for (; i < maxi;)
        {
            lock (locker)
            {
                Console.Write("A" + i + " ");
                i++;
            }
        }
    }
    static void GoB()
    {
        for (; i < maxi;)
        {
            lock (locker)
            {
                Console.Write("B" + i + " ");
                i++;
            }
        }
    }
}
