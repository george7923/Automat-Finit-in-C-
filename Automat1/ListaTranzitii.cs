using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat1
{
    public class ListaTranzitii
    {
        private List<Tranzitie> lista;
        

        public ListaTranzitii()
        {
            this.lista = new List<Tranzitie>();

        }
        public void AdaugaTranzitie(Tranzitie tr)
        {
            this.lista.Add(tr);
        }
        public Tranzitie findTranzitie(String stare, char simbol)
        {
            for (int i = 0; i < this.lista.Count(); i++)
            {
                Tranzitie timp = this.lista[i];
                // || (timp.getStareInceput().Equals(stare) && timp.getSimbol()==' ')
                if (timp.getStareInceput().Equals(stare) && timp.getSimbol() == simbol)
                {
                    return timp;
                }
            }
            return null;
        }
        public List<Tranzitie> ReturnLista()
        {
            return this.lista;
        }
    }
}
