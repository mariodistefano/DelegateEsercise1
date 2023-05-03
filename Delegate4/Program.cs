
using System;
using System.Drawing;
using static Delegate4.Program.Intermediary;

namespace Delegate4
{



    internal class Program
    {
        static void Main(string[] args)
        {
         
            EUDigitalWallet digitalWallet = new EUDigitalWallet("DSTMNC97T29C351W");
            Assicurazione.CreatePlan(digitalWallet.GetClinicalStatus());
            

        }

        class EUDigitalWallet : Intermediary
        {
            string _owner;
            bool _diploma = true;
            string _taxinfo = "tassa";
            bool _penalStatus = false;
            string _clinicalStatus = "Situazione sanitaria è OK";

            public EUDigitalWallet(string CF)
            {
                _owner = CF;
            }


            public bool GetDiploma() 
            {
                Console.WriteLine(_diploma);
                return _diploma;

            }

            public bool GetPenalStatus() 
            {
                Console.WriteLine(_penalStatus);
                return _penalStatus;
            }

            public ClinicalWallet GetClinicalStatus() 
            {
                ClinicalWallet clinicalWall = new ClinicalWallet(true);
                return clinicalWall;
            }


        }



        public class Intermediary
        {
            public class ClinicalWallet
            {
                public bool _clinicalStatus;

                public ClinicalWallet(bool clinicalStatus)
                {
                    _clinicalStatus = clinicalStatus;
                }

            }

        }


        public class Person
        {
            public string CF { get; set; }

        }


        class MobileApp 
        {
            public Person user { get; set; }

            public MobileApp(Person person)
            {
                user = person;
            }

            //public void NotifyMe(string msg) 
            //{
            //    Console.WriteLine("La tua assicuzione è pronta");
            //}
                
        }

        
        class Assicurazione
        {
            public static void CreatePlan(ClinicalWallet clinicalWall)
            {
                if (clinicalWall._clinicalStatus) 
                {
                   Console.WriteLine("la tua assicurazione è pronta");
                }else
                {
                  Console.WriteLine("la tua situazione clinica non è buona");  
                }
                
                
            }
        }




    }
}


