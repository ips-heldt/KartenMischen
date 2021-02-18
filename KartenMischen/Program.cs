using System;

namespace KartenMischen
{
    class Program
    {
        static void Main(string[] args)
        {
            Stapel stapel = new Stapel(32);

            Console.Clear();
            Console.Write(stapel.ToString());

            Console.ReadKey();
        }
    }
}
