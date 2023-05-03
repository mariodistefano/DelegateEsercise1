using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static EMACovidEU.Program;
using static EMACovidEU.Program.EMA;

namespace EMACovidEU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var paesi = new List<Paese>()
            {
                new Paese("Italia", 500),
                new Paese("francia", 30000),
                new Paese("RegnoUnito", 7000),
                new Paese("svizzera", 20000),
            };
            
            EMA ema = new EMA();
            SumTotCovidEU SommaTotaleCovid = ema.CalcTotaleCovidEU;
            ema.AggiungiPaese(paesi);

         
            ema.CalcTotaleCovidEU();
       
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"il totale dei malati di COVID a livello europeo è di : {ema.TotCovidEU} " );
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("----------------------------------------------------");
            ema.AggiornaNumeroMalati("francia", 222, SommaTotaleCovid);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"il totale aggiornato dei malati di covid al livello europeo è di : {ema.TotCovidEU}");
            Console.ForegroundColor = ConsoleColor.White;

      
        }


        public delegate int SumTotCovidEU();


        public class EMA
        {
            private List<Paese> _paesi = new List<Paese>();
            public int TotCovidEU;
           
            public void AggiungiPaese(Paese paese)
            {
                _paesi.Add(paese);
            }

            public void AggiungiPaese(IEnumerable<Paese> paesi)
            {
                _paesi.AddRange(paesi);
            }

            public void AggiornaNumeroMalati(string nomePaese, int numeroMalati , SumTotCovidEU del)
            {
                var paese = _paesi.FirstOrDefault(p => p.Name == nomePaese);
                if (paese != null)
                {
                    
                    paese.TotCovid = numeroMalati;

                    paese.AddPovitiveVirusPaese(numeroMalati, del);

                    Console.WriteLine($"il totale del paese : {nomePaese} è stato aggiornato : {paese.TotCovid}");
                }
            }

            public int CalcTotaleCovidEU() 
            {
                TotCovidEU = 0;

                foreach (Paese country in _paesi)
                {
                    TotCovidEU += country.TotCovid;
                    
                }
                return TotCovidEU;
            }
        }
            public class Paese
            {
                    public int _TotCovid;

                    public string _name;
                    public int TotCovid { get => _TotCovid; set => _TotCovid = value; }
                    public string Name { get => _name; set => _name = value; }

                    public Paese(string name, int totcovid)
                    {
                        TotCovid = totcovid;
                        Name = name;
                    }


                    public void AddPovitiveVirusPaese(int num, SumTotCovidEU sumTotCovidEU)
                    {
                        _TotCovid = num;
                        sumTotCovidEU();
                    }
                    public void ShowTotCovid() 
                    {
                        Console.WriteLine($"totale malati covid nel Paese: {Name} è di : {TotCovid}");
                    }

            }
        
    }
}
