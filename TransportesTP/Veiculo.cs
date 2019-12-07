using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesTP
{
    class Veiculo
    {
        private int id;
        private string placa;
        private int lotacao;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Placa
        {
            get
            {
                return placa;
            }

            set
            {
                placa = value;
            }
        }

        public int Lotacao
        {
            get
            {
                return lotacao;
            }

            set
            {
                lotacao = value;
            }
        }
        public Veiculo() { }
        public Veiculo(int id)
        {
            this.Id = id;
        }
        public Veiculo(int _id,string _placa,int _lotacao)
        {
            this.Id = _id;
            this.Placa = _placa;
            this.Lotacao = _lotacao;
        }
        public override bool Equals(object obj)
        {

            return this.Id.Equals(((Veiculo)obj).Id);
        }

    }
}
