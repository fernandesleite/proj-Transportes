using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesTP
{
    class Viagem
    {
        private int ID;
        private Garagem origem;
        private Garagem destino;
        private Veiculo veiculo;

        public int ID1
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        internal Garagem Origem
        {
            get
            {
                return origem;
            }

            set
            {
                origem = value;
            }
        }

        internal Garagem Destino
        {
            get
            {
                return destino;
            }

            set
            {
                destino = value;
            }
        }

        internal Veiculo Veiculo
        {
            get
            {
                return veiculo;
            }

            set
            {
                veiculo = value;
            }
        }
        public Viagem(int id, Garagem origem, Garagem destino, Veiculo veiculo)
        {
            this.ID1 = id;
            this.Origem = origem;
            this.Destino = destino;
            this.Veiculo = veiculo;
        }
    }
}
