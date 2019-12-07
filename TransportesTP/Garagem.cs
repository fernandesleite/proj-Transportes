using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesTP
{
    class Garagem
    {
        private int id;
        private string local;
        private int count = 0;
        private int countPessoas = 0;
        public Queue<int> pessoas = new Queue<int>();
        public Stack<Veiculo> veiculos = new Stack<Veiculo>();


        public Garagem(int id, string local)
        {
            this.id = id;
            this.local = local;
        }

        public Garagem(int id)
        {
            this.id = id;
        }

        public Garagem()
        {
        }
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

        public string Local
        {
            get
            {
                return local;
            }

            set
            {
                local = value;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public int CountPessoas
        {
            get
            {
                return countPessoas;
            }

            set
            {
                countPessoas = value;
            }
        }

        public Queue<int> Pessoas
        {
            get
            {
                return pessoas;
            }

            set
            {
                pessoas = value;
            }
        }

        public int qtdeDeveiculos()
        {
            return veiculos.Count; 
        }
        public int potencialDeTransporte()
        {
            int count = 0;
            foreach (Veiculo v in veiculos)
            {
                count += v.Lotacao;
            }
            return count;

        }
        public bool vaiViajar()
        {
            if(veiculos.Count > 0)
            {
                if (pessoas.Count >= veiculos.Peek().Lotacao)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void addPessoas()
        {
            pessoas.Enqueue(CountPessoas++);
        }
        public void removePessoas()
        {
            pessoas.Dequeue();
        }
        public override bool Equals(object obj)
        {
            return this.Id.Equals(((Garagem)obj).Id);
        }


    }
}
