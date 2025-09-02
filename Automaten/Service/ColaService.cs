using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automaten.Repository;

namespace Automaten.Service
{
    internal class ColaService
    {

        private readonly ColaRepository _repository;

        public ColaService(ColaRepository repository)
        {
            _repository = repository;
        }

        public void DisplayAllColas()
        {
            List<Cola> colas = _repository.GetAllColas();
            Console.WriteLine(" tilgængelige sodavand ");

            for (int i = 0; i < colas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {colas[i].Name} - {colas[i].Price} kr");
            }
        }

        public bool ProcessPurchase(int userChoice, int amountPaid)
        {
            int colaIndex = userChoice - 1; // Konverter fra 1-based til 0-based
            if (!_repository.ColaExists(colaIndex))
            {
                return false;
            }

            Cola cola = _repository.GetColaByIndex(colaIndex);

            if (amountPaid >= cola.Price)
            {
                _repository.RemoveCola(colaIndex);
                return true;
            }
            return false;
        }

        public int CalculateChange(int userChoice, int amountPaid)
        {
            int colaIndex = userChoice - 1; // Konverter fra 1-based til 0-based
            Cola cola = _repository.GetColaByIndex(colaIndex);
            return amountPaid - cola.Price;
        }

        public Cola GetColaInfo(int userChoice)
        {
            int colaIndex = userChoice - 1; // Konverter fra 1-based til 0-based
            return _repository.GetColaByIndex(colaIndex);
        }


    }
}
