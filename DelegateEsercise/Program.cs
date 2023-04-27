using System;

namespace DelegateEsercise
{
    internal class Program
    {
        
        
        public delegate int SumDelegate(int a, int b);
        public delegate void ExecuteDelegate(SumDelegate sumDelegate, int a, int b);

        static void Main(string[] args)
        {
            Delegate del = new Delegate();
            SumDelegate sumDelegate = (a, b) => a + b;
            ExecuteDelegate executeDelegate = (delegateToExecute, a, b) =>
            {
                int result = delegateToExecute(a, b);
                Console.WriteLine(result);
            };

            del.RunDelegate(executeDelegate, sumDelegate, 3, 5);
        }


        public class Delegate
        {
            public void RunDelegate(ExecuteDelegate executeDelegate, SumDelegate sumDelegate, int a, int b)
            {
                executeDelegate(sumDelegate, a, b);
            }
        }


    }
}
