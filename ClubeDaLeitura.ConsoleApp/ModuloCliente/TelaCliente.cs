﻿using ClubeDaLeitura.ConsoleApp.RepositorioCaixa;
using ClubeDaLeitura.ConsoleApp.RepositorioCompartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCliente
{
   public class TelaCliente
    {
        public Cliente[] clientes = new Cliente[100];
        public int contadorClientes = 0;
        public TelaCaixa telaCaixa;

        public TelaCliente(TelaCaixa telaCaixa)
        {
            this.telaCaixa = telaCaixa;
        }

        public string ApresentarMenuCliente()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Gestão de clientes");
            Console.WriteLine("------------------");
            Console.WriteLine();
            Console.WriteLine("Escolha a operação desejada: ");
            Console.WriteLine("1 - Cadastrar novo cliente: ");
            Console.WriteLine("2 - Editar cadastro de cliente: ");
            Console.WriteLine("3 - Excluir cadastro de cliente: ");
            Console.WriteLine("4 - Visualizar clientes: ");

            string menuCliente = Console.ReadLine();

            return menuCliente;
        }

        public void CadastrarCliente()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Cadastrando cliente...");
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.Write("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone para contato: ");
            int telefone = Convert.ToInt32(Console.ReadLine());

            Cliente novoCliente = new Cliente(nomeCliente, nomeResponsavel, telefone);
            novoCliente.Id = GeradorIds.GerarIdCliente();

            clientes[contadorClientes++] = novoCliente;
        }
        public void EditarCliente()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Editando cliente...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarCliente(false);

            Console.Write("Digite o ID de registro do cliente que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o nome do cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone para contato: ");
            int telefone = Convert.ToInt32(Console.ReadLine());

            Cliente novoCliente = new Cliente(nomeCliente, nomeResponsavel, telefone);

            bool conseguiuEditar = false;

            for (int i = 0; i < clientes.Length; i++)
            {
                if (clientes[i] == null) continue;

                else if (clientes[i].Id == idSelecionado)
                {
                    clientes[i].NomeCliente = novoCliente.NomeCliente;
                    clientes[i].NomeResponsavel = novoCliente.NomeResponsavel;
                    clientes[i].Telefone = novoCliente.Telefone;

                    conseguiuEditar = true;
                }
                if (!conseguiuEditar)
                {
                    Console.WriteLine("Houve um erro durante a edição das informações do cliente...");
                    return;
                };

                Console.WriteLine("As informações do cliente foram editadas com sucesso!");
            }
        }

        public void ExcluirCliente()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Excluindo cliente...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarCliente(false);

            Console.Write("Digite o ID do cliente que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = false;

            for (int i = 0; i < clientes.Length; i++)
            {
                if (clientes[i] == null) continue;

                else if (clientes[i].Id == idSelecionado)
                {
                    clientes[i] = null;

                    conseguiuExcluir = true;
                }
            }

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusão do cliente...");
            }
            Console.WriteLine();
            Console.WriteLine("O cliente foi devidamente excluído do sistema.");
        }

        public void VisualizarCliente(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("----------------------");
                Console.WriteLine("Visualizando cliente...");
                Console.WriteLine("----------------------");
                Console.WriteLine();
            }
            Console.WriteLine();
            
            Console.WriteLine("{0, - 8} | {1, -12} | {2, -12} | {3, -10}",
                               "ID", "Nome", "Responsável", "Contato");


            for (int i = 0; i < clientes.Length; i++)
            {
                Cliente clienteSelecionado = clientes[i];

                if (clienteSelecionado == null) continue;


                Console.WriteLine("{0, - 8} | {1, -12} | {2, -12} | {3, -10}",
                clienteSelecionado.Id, clienteSelecionado.NomeCliente, clienteSelecionado.NomeResponsavel, clienteSelecionado.Telefone);
            }
        }

    }
}
