using System;

delegate double GenerateValue(int index);

namespace _08_delegats
{
    internal class Program
    {
        private static Random random = new(Guid.NewGuid().GetHashCode());

        private static double[] InitArray(int arraySize, GenerateValue generateValue)
        {
            double[] array = new double[arraySize];
            for (int i = 0; i < arraySize; i++)
                array[i] = generateValue(i);
            return array;
        }
        private static Func<A, R> Y<A, R>(Func<Func<A, R>, Func<A, R>> f)
        {
            Func<A, R>? g = null;
            g = f(a => g(a));
            return g;
        }
        static void Main()
        {
            Func<int, int> fib = Y<int, int>(f => n => n > 1 ? f(n - 1) + f(n - 2) : n);

            double[] fibArray = InitArray(10, (i) => fib(i));
            foreach (var item in fibArray) Console.Write(item + " ");

            Console.WriteLine();

            double[] randomValuesArray = InitArray(15, (_) => random.Next(100));
            foreach (var item in randomValuesArray) Console.Write(item + " ");

            Console.WriteLine();

            double[] up3 = InitArray(20, (i) => i * 3);
            foreach (var item in up3) Console.Write(item + " ");
        }
    }
}