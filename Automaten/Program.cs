using Automaten.Repository;
using Automaten.Service;

namespace Automaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ColaRepository repository = new ColaRepository();
           ColaService colaService = new ColaService(repository);

            //vis alle sodavand
            colaService.DisplayAllColas();


            // vælg en bestem sodavand
            Console.WriteLine(" vælg en sodavand ");
            int valg = Convert.ToInt32(Console.ReadLine());


            if (colaService.GetColaInfo(valg) !=null)
            {
                Cola cola = colaService.GetColaInfo(valg);
                Console.WriteLine($" du har valgt: {cola.Name}");
                Console.WriteLine($"Pris: {cola.Price} kr");


               //betaling 
                Console.WriteLine("indbetal penge");
                int indbetalt = Convert.ToInt32(Console.ReadLine());


                if (colaService.ProcessPurchase(valg, indbetalt))
                {
                    int change = colaService.CalculateChange(valg, indbetalt);
                    Console.WriteLine($" Tak for købet! Du får {change} kr tilbage ");

                    Console.WriteLine("___________________________");

                    //viser tilgangelige sodavand 
                    colaService.DisplayAllColas();

                }
                else
                {
                    Console.WriteLine("Ikke nok penge indbetalt! Transaktion annulleret.");
                }


            }
            else
            {
                Console.WriteLine(" ugyldig valg ");
            }

            





        }
    }
}
