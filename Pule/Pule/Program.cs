using System;

namespace Pule
{
    class Program
    {
        public static void wypisywanie()
        {
            for (int n = 0; n < Pula1._available.Count; n++)
            {
                Console.Write(Pula1._available[n].Points);
                Console.Write(',');
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var builder = new ThreadBuilder();
            int i = 4;
            var res1 = builder.ReturnValues("Pula1", i);
            wypisywanie();
            var res2 = builder.ReturnValues("Pula1", i);
            wypisywanie();
            var res7 = builder.ReturnValues("Pula1", 5);
            wypisywanie();
            Console.WriteLine(res1);
            Console.WriteLine(res2);
            Console.WriteLine(res7);
            
        }
    }
}