using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesTP
{
    class Veiculos
    {
        private List<Veiculo> veic;

        internal List<Veiculo> Veic
        {
            get
            {
                return veic;
            }

            set
            {
                veic = value;
            }
        }
        public Veiculos(List<Veiculo> _veic)
        {
            Veic = _veic;
        }

        public void incluir(Veiculo veiculo)
        {
            Veiculo v = new Veiculo();

           // Veic.Add(v);
            foreach(Veiculo lveiculo in Veic)
            {
                //Veic.Add(v);
                Veic.Add(veiculo);
                
            }
        }
    }
}
