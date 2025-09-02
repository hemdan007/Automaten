using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten.Repository
{
    internal class ColaRepository
    {

        private List<Cola> _colaliste = new List<Cola>();

        public ColaRepository()
        {

            _colaliste = new List<Cola>
            {
                new Cola("Coca-Cola", 15),
                new Cola("Fanta", 20),
                new Cola("Sprite", 20),
                new Cola("Faxe kondi", 20)

            };

        }

        public List<Cola> GetAllColas()
        {
            return _colaliste;
        }

        public Cola GetColaByIndex(int index)
        {
            if (index >= 0 &&  index < _colaliste.Count)
            {
                return _colaliste[index];
            }
            return null;
        }

        public void RemoveCola(int index)
        {
            if (index >= 0 && index < _colaliste?.Count)
            {
                _colaliste.RemoveAt(index);
            }
        }

        public bool ColaExists(int index)
        {
            return index >= 0 && index < _colaliste?.Count;
        }


    }
}
