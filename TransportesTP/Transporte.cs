using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesTP
{
    class Transporte
    {
        private Veiculo veiculo;
        private int qtdTransportada;

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

        public int QtdTransportada
        {
            get
            {
                return qtdTransportada;
            }

            set
            {
                qtdTransportada = value;
            }
        }

        public Transporte (Veiculo veiculo)
        {
            this.veiculo = veiculo;
            this.qtdTransportada = veiculo.Lotacao;
        }
    }
}
