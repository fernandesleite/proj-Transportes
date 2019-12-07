using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesTP
{
    class Viagens
    {
        public Queue<Viagem> viagens = new Queue<Viagem>();
        
        internal Queue<Viagem> _Viagens
        {
            get
            {
                return viagens;
            }

            set
            {
                viagens = value;
            }
        }
        
        public void incluir (Viagem viagem)
        {
            _Viagens.Enqueue(viagem);
        }
    }
}
