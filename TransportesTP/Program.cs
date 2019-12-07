using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportesTP
{
    class Program
    {
        private static Garagens garagens = new Garagens();
        static void Main(string[] args)
        {
            
            garagens.incluir(new Garagem(1, "Congonhas"));
            garagens.incluir(new Garagem(2, "Guarulhos"));

            garagens.incluirVeic(new Veiculo(1, "CARRO1", 20));
            garagens.incluirVeic(new Veiculo(2, "CARRO2", 30));
            garagens.incluirVeic(new Veiculo(3, "CARRO3", 22));
            garagens.incluirVeic(new Veiculo(4, "CARRO4", 15));
            garagens.incluirVeic(new Veiculo(5, "CARRO5", 2));
            garagens.incluirVeic(new Veiculo(6, "CARRO6", 48));
            garagens.incluirVeic(new Veiculo(7, "CARRO7", 12));
            garagens.incluirVeic(new Veiculo(8, "CARRO8", 20));
            
                int opcao;
                do
                {
                    mostrarMenu();
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao > 10)
                    {
                        Console.WriteLine("Opcao invalida!\n");
                    }
                    try
                    {
                        switch (opcao)
                        {
                            case 0:
                                break;
                            case 1:
                                cadastrarVeiculo();
                                break;
                            case 2:
                                cadastrarGaragem();
                                break;
                            case 3:
                                iniciarJornada();
                                break;
                            case 4:
                                encerrarJornada();
                                break;
                            case 5:
                                liberarViagem();
                                break;
                            case 6:
                                listarVeiculos();
                                break;
                            case 7:
                                qtdeDeViagens();
                                break;
                            case 8:
                                listarViagens();
                                break;
                            case 9:
                                qtdeDePassageiros();
                                break;
                            case 10:
                                limparTela();
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERRO: {0}", e.ToString());
                    }

                } while (opcao != 0);

             
        }
        private static void mostrarMenu()
        {
            Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
            Console.WriteLine("0.  Sair");
            Console.WriteLine("1.  Cadastrar veículo");
            Console.WriteLine("2.  Cadastrar garagem");
            Console.WriteLine("3.  Iniciar jornada");
            Console.WriteLine("4.  Encerrar jornada");
            Console.WriteLine("5.  Liberar viagem de uma determinada origem para um determinado destino");
            Console.WriteLine("6.  Listar veículos em determinada garagem (informando a qtde de veículos e seu potencial de transporte)");
            Console.WriteLine("7.  Informar qtde de viagens efetuadas de uma determinada origem para um determinado destino ");
            Console.WriteLine("8.  Listar viagens efetuadas de uma determinada origem para um determinado destino");
            Console.WriteLine("9.  Informar qtde de passageiros transportados de uma determinada origem para um determinado destino");
            Console.WriteLine("10. Limpar tela");
            Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
            Console.Write("Opção: ");
        }
        public static void cadastrarVeiculo()
        {
            if (!garagens.jornadaAtiva)
            {
                Console.WriteLine("Digite a placa do veículo: ");
                string placa = Console.ReadLine();
                Console.WriteLine("Digite a lotação máxima do veículo: ");
                int lotacao = int.Parse(Console.ReadLine());
                garagens.incluirVeic(new Veiculo(garagens.novoIdVeiculo(), placa, lotacao));
                Console.WriteLine("Veículo cadastrado com sucesso...");
            }
            else
            {
                Console.WriteLine("Não é possível cadastrar veiculos: Jornada ativa");
            }
        }
        public static void cadastrarGaragem()
        {
            if (!garagens.jornadaAtiva)
            {
                Console.WriteLine("Digite o nome da garagem: ");
                string nomeG = Console.ReadLine();
                garagens.incluir(new Garagem(garagens.novoIdGaragem(), nomeG));
                Console.WriteLine("Garagem cadastrada com sucesso!");
            }
            else
            {
                Console.WriteLine("Não é possível cadastrar garagens: Jornada ativa");
            }
        }
        public static void iniciarJornada()
        {
            if (garagens.jornadaAtiva)
            {
                Console.WriteLine("A jornada já está iniciada!");
            }
            else if (garagens.veiculos.Count <= 0)
            {
                Console.WriteLine("Não há veiculos!");
            }
            else if (garagens.garagens.Count <= 0)
            {
                Console.WriteLine("Não há garagens!");
            }
            else
            {
                garagens.iniciarJornada();
                Console.WriteLine("A jornada foi iniciada!");
            }
        }
        public static void encerrarJornada()
        {
            if (!garagens.jornadaAtiva)
            {
                Console.WriteLine("A jornada já está encerrada!");
            }
            else
            {
                garagens.encerrarJornada();
                Console.WriteLine("A jornada foi encerrada!");
            }
        }
        public static void liberarViagem()
        {
            if (garagens.jornadaAtiva)
            {
                Console.WriteLine("Digite o ID da garagem de origem: ");
                int idG = int.Parse(Console.ReadLine());
                idG--;

                if (idG < garagens.garagens.Count)
                {
                    Garagem gOrigem = garagens.garagens[idG];

                    gOrigem.addPessoas();
                    Console.WriteLine("Adicionada uma pessoa na fila");

                    if (gOrigem.veiculos.Count > 0)
                    {

                        if (gOrigem.vaiViajar())
                        {
                            int indexGDestino = gOrigem.Id + 1;
                            if (indexGDestino == garagens.garagens.Count())
                            {
                                indexGDestino = 0;
                            }

                            Garagem gDestino = garagens.garagens[indexGDestino];

                            Veiculo vVeiculo = gOrigem.veiculos.Peek();

                            for (int i = 0; i < gOrigem.veiculos.First().Lotacao; i++)
                            {
                                gOrigem.removePessoas();
                            }

                            garagens.executaViagem(gOrigem, gDestino, vVeiculo);

                            while (gDestino.veiculos.Count == 1 && vVeiculo.Lotacao >= gDestino.pessoas.Count)
                            {
                                gOrigem = gDestino;

                                indexGDestino = gOrigem.Id + 1;
                                if (indexGDestino == garagens.garagens.Count())
                                {
                                    indexGDestino = 0;
                                }

                                gDestino = garagens.garagens[indexGDestino];

                                vVeiculo = gOrigem.veiculos.Peek();

                                for (int i = 0; i < gOrigem.veiculos.First().Lotacao; i++)
                                {
                                    gOrigem.removePessoas();
                                }

                                garagens.executaViagem(gOrigem, gDestino, vVeiculo);
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há veículos disponíveis");
                    }
                }
                else
                {
                    Console.WriteLine("Não existe uma garagem com o ID informado!");
                }
            }
            else
            {
                Console.WriteLine("Não é possível entrar na fila enquanto a jornada não estiver ativa!");
            }
        }
        public static void listarVeiculos()
        {
            if (garagens.jornadaAtiva)
            {
                Console.WriteLine("Selecione a garagem a qual deseja consultar os veículos: ");
                int pos = int.Parse(Console.ReadLine());
                pos--;
                foreach (Veiculo v in garagens.garagens[pos].veiculos)
                {
                    Console.WriteLine("ID: " + v.Id + " | Placa: " + v.Placa + " | Lotação: " + v.Lotacao);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos nas garagens pois a jornada está ativa");
            }
        }
        public static void qtdeDeViagens()
        {
            Console.WriteLine("Digite a origem: ");
            String localOrigem = Console.ReadLine();
            int cont = 0;
            Console.WriteLine("Digite o destino: ");
            String localDestino = Console.ReadLine();
            foreach (Viagem v in garagens.viagens._Viagens)
            {
                if(v.Destino.Equals(new Garagem(0, localDestino).Local) && v.Origem.Equals(new Garagem(0, localOrigem).Local))
                {
                    cont++;
                }
            }
            Console.WriteLine("Foram realizadas {0} viagens", cont);
        }
        public static void listarViagens()
        {
            Console.WriteLine("Viagens: ");
            foreach (Viagem v in garagens.viagens.viagens)
            {
                Console.WriteLine("\nID: " + v.ID1);
                Console.WriteLine("Garagem de origem: " + v.Origem.Local);
                Console.WriteLine("Garagem de destino: " + v.Destino.Local);
                Console.WriteLine("Veículo: " + v.Veiculo.Placa);

            }
        }
        public static void qtdeDePassageiros()
        {
            Console.WriteLine("Digite a origem: ");
            String localOrigem = Console.ReadLine();
            int cont = 0;
            Console.WriteLine("Digite o destino: ");
            String localDestino = Console.ReadLine();
            foreach (Viagem v in garagens.viagens._Viagens)
            {
                if (v.Destino.Equals(new Garagem(0, localDestino).Local) && v.Origem.Equals(new Garagem(0, localOrigem).Local))
                {
                    cont += v.Veiculo.Lotacao;
                }
            }
            Console.WriteLine("Quantidade de passageiros: {0}", cont);
        }
        public static void limparTela()
        {
            Console.Clear();
        }
    }
}
