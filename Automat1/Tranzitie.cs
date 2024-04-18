using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automat1
{
    public class Tranzitie
    {
        private String stare_inceput;
        private char simbol;
        private String stare_finala;
        private String output;
        
        public Tranzitie(string stare_inceput, char simbol, String stare_finala)
        {
            this.stare_inceput = stare_inceput;
            this.simbol = simbol;
            this.stare_finala = stare_finala;
            
        }
        public Tranzitie(string stare_inceput, char simbol, String stare_finala, String output)
        {
            this.stare_inceput = stare_inceput;
            this.simbol = simbol;
            this.stare_finala = stare_finala;
            this.output = output;
        }
        public String getStareInceput()
        {
            return stare_inceput;
        }
        public char getSimbol()
        {
            return simbol;
        }
        public String getStareFinala()
        {
            return stare_finala;
        }
        public String getOutput()
        {
            return output;
        }
        public bool Egal(Tranzitie t)
        {
           
            if (t == null)
            {
                return false;
            }
            return (t.getStareInceput() == this.getStareInceput()) && (t.getSimbol()==this.getSimbol())&&(t.getStareFinala()==this.getStareFinala());
        }

    }
}
