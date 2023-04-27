using System;
using System.Runtime.InteropServices;

namespace Delegate3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Func<int, int, int> multiplyFunc = (a, b) => a * b;
            Predicate<int> greaterThanFunc = (result) => result > 10;
            Action<int> callback = (result) => Console.WriteLine("Il risultato della moltiplicazione è maggiore di 10");


            Func<Func<int, int, int>, Predicate<int>, Action<int>, bool> checkFunc = (multipFunc, predicateFunc, callbackFunc) =>
            {
                int result = multipFunc(1, 7);
                bool isGreater = predicateFunc(result);


                if (isGreater)
                {
                    callbackFunc(result);
                }


                return isGreater;
            };

            bool isProductGreater = checkFunc(multiplyFunc, greaterThanFunc, callback);


            Console.WriteLine($"Il prodotto è maggiore di 10? : {isProductGreater}");



        }
    }
}
