using System;

namespace EsercizioCEOEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Istituto SANPAOLO = new Istituto { Nome = "sanpaolo" , CEO = "Pippo"};
            Istituto uciCinema = new Istituto { Nome = "Ucicinema" , CEO = "tino"};
            OrganoDiControllo ControlloCambioCEO = new OrganoDiControllo();

            SANPAOLO.CambioCEO += ControlloCambioCEO.VisualizzaCambioCEO;
            uciCinema.CambioCEO += ControlloCambioCEO.VisualizzaCambioCEO;

            SANPAOLO.CambiaCEO("mario");
            uciCinema.CambiaCEO("nomenuovo");
        }
        public class Istituto
        {
            public string Nome { get; set; }
            public string CEO { get; set; }

            public event EventHandler CambioCEO;


            public void CambiaCEO(string nuovoCEO) 
            {
                CEO = nuovoCEO;
                OnCambioCEO();
            }
            protected virtual void OnCambioCEO() 
            {
                if (CambioCEO != null)
                {
                    CambioCEO(this, EventArgs.Empty);
                }
            }

        }

        public class OrganoDiControllo
        {
            public void VisualizzaCambioCEO(Object sender, EventArgs e)
            {
                Istituto commercialBank = (Istituto)sender;
                Console.WriteLine($"l'istituto {commercialBank.Nome} ha cambiato il CEO, il nuovo è : {commercialBank.CEO}");
            }
        }

    }
}
