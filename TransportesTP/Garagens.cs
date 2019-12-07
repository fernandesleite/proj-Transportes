using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesTP
{
    class Garagens
    {
        private int contaGaragem = 1;
        private int contaVeiculos = 1;
        private int contaViagens = 1;
        public List<Garagem> garagens = new List<Garagem>();
        public bool jornadaAtiva;
        public List<Veiculo> veiculos = new List<Veiculo>();
        public List<Transporte> transportes = new List<Transporte>();
        public Viagens viagens = new Viagens();
        public bool JornadaAtiva
        {
            get
            {
                return jornadaAtiva;
            }

            set
            {
                jornadaAtiva = value;
            }
        }

        
        internal List<Garagem> _Garagens
        {
            get
            {
                return garagens;
            }

            set
            {
                garagens = value;
            }
        }
        public void executaViagem(Garagem gOrigem, Garagem gDestino, Veiculo vViagem)
        {
            

            viagens.incluir(new Viagem(contaViagens, gOrigem, gDestino, vViagem));
            contaViagens++;

            transportes.Add(new Transporte(pesquisarVeiculo(new Veiculo(veiculos.First().Id))));

            //tira o primeiro veículo da garagem de origem e envia pra garagem de destino
            garagens[gDestino.Id].veiculos.Push(garagens[gOrigem.Id].veiculos.Pop());
        }
        /*
        public Garagens (List<Garagem> garag)
        {
            garagens = garag;
        }
        */
        public bool incluirVeic(Veiculo veiculo)
        {
            bool aux = false;
            int aux1 = veiculos.IndexOf(veiculo);

            if (aux1 == -1)
            {
                veiculos.Add(veiculo);
                aux = true;
            }

            return aux;
        }
        public void incluir (Garagem garagem)
        {
            garagens.Add(garagem);
        }

        public void iniciarJornada()
        {
            int cVeiculos = veiculos.Count();
            int cGaragens = garagens.Count();
            int proxG = 0;
            //int antiG = 0;


            for (int cV = 0; cV < cVeiculos; cV++)
            {
                garagens[proxG].veiculos.Push(veiculos[cV]);
                proxG++;
                if (proxG >= cGaragens)
                {
                    proxG = 0;
                }
            }
            jornadaAtiva = true;
        }
        public List<Transporte> encerrarJornada()
        {
            for (int i = 0; i < garagens.Count; i++)
            {
                garagens[i].veiculos.Clear();
                foreach (Veiculo v in garagens[i].veiculos)
                {
                    

                    veiculos.Add(v);
                }
            }

            foreach (Garagem gar in garagens)
            {
                gar.veiculos.Clear();
            }

            jornadaAtiva = false;
            return transportes;
        }
        public Veiculo pesquisarVeiculo(Veiculo veiculo)
        {
            Veiculo veiAchado = new Veiculo();
            int i = veiculos.IndexOf(veiculo);
            if (i >= 0)
                veiAchado = veiculos[i];
            else
                veiAchado = null;
            return veiAchado;
        }
        public Garagem pesquisarGaragem(Garagem garagem)
        {
            Garagem garAchado = new Garagem();
            int i = garagens.IndexOf(garagem);
            if (i >= 0)
                garAchado = garagens[i];
            else
                garAchado = null;
            return garAchado;
        }
        public int novoIdGaragem()
        {
            int novoId = contaGaragem++;
            return novoId;
        }

        public int novoIdVeiculo()
        {
            int novoId = contaVeiculos++;
            return novoId;
        }


    }
}
