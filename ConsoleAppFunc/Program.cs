using System;

namespace ConsoleAppFunc
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Func<int, int, int> sumFunc = (a, b) => a + b;

            Func<Func<int, int, int>, int, int, int> executeFunc = (funcToExecute, a, b) =>
            {
                int result = funcToExecute(a, b);
                Console.WriteLine(result);
                return result;
            };
            Func<Func<Func<int, int, int>, int, int, int>, int> runFunc = (funcToRun) =>
            {
                int result = funcToRun(sumFunc, 10, 5);
                return result;
            };

            int finalResult = runFunc(executeFunc);
            Console.WriteLine(finalResult);
        }
    }
}
