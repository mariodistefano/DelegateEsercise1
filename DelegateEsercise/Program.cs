using System;

namespace DelegateEsercise
{
    internal class Program
    {
        
        //   prende come parametro due int   e restituisce un int
        public delegate int SumDelegate(int a, int b);
        //   questa funzione prende come parametro una funzione di tipo SumDelegate  e due int
        public delegate void ExecuteDelegate(SumDelegate sumDelegate, int a, int b);

        static void Main(string[] args)
        {
            DelegateRun del = new DelegateRun();
            // definisco il deledate SumDelegate che rappresenta la funzione di somma
            SumDelegate sumDelegate = (a, b) => a + b;
            // definisco il delegate ExcuteDelegate che esegue il SumDelegate passato come parametro
            ExecuteDelegate executeDelegate = (delegateToExecute, a, b) =>
            {
                int result = delegateToExecute(a, b);
                Console.WriteLine(result);
            };

            //chiamata della funzione che prende i delegate e i due parametri
            del.RunDelegate(executeDelegate, sumDelegate, 3, 5);
        }


        public class DelegateRun
        {

           // la funzione RunDelegate esegue il delegate excuteDelegate passando il sumDelegate e i numeri come parametro 
           // la funzione ExcuteDelegate esegue il delegate sumDelegate con i relativi parametri numerici e quindi stampa il risultato in console
            public void RunDelegate(ExecuteDelegate executeDelegate, SumDelegate sumDelegate, int a, int b)
            {
                executeDelegate(sumDelegate, a, b);
            }
        }


    }
}
