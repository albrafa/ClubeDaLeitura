using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloCliente;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Numerics;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    class TelaEmprestimo
    {
        public RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioCaixa repositorioCaixa;
        public RepositorioCliente repositorioCliente;
        public RepositorioRevista repositorioRevista;

        public TelaCliente telaCliente;
        public TelaRevista telaRevista;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioCaixa repositorioCaixa,
            RepositorioCliente repositorioCliente, RepositorioRevista repositorioRevista)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioCaixa = repositorioCaixa;
            this.repositorioCliente = repositorioCliente;
            this.repositorioRevista = repositorioRevista;
        }    

        public string ApresentarMenuEmprestimo()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Gestão de empréstimos e devoluções");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Selecione a operação desejada: ");
            Console.WriteLine();
            Console.WriteLine("1 - Registrar novo empréstimo: ");
            Console.WriteLine("2 - Registrar devolução: ");
            Console.WriteLine("3 - Visualizar empréstimos: ");
            Console.WriteLine();

            string menuEmprestimo = Console.ReadLine();

            return menuEmprestimo;
        }

        public void RegistrarEmprestimo()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Registrando empréstimo...");
            Console.WriteLine("-------------------------");
            Console.WriteLine();

            //visualizar a lista de clientes
            telaCliente.VisualizarClientes(false);

            //pegando o cliente
            Console.Write("Digite o ID do cliente: ");
            int idClienteSelecionado = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            telaRevista.VisualizarRevistas(false);

            Console.Write("Digite o ID da revista desejada: ");
            int idRevistaSelecionada = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Cliente clienteSelecionado = repositorioCliente.SelecionarClientePorId(idClienteSelecionado);
            
            Revista revistaSelecionada = repositorioRevista.SelecionarRevistaPorId(idRevistaSelecionada);

            Emprestimo novoEmprestimo = new Emprestimo(clienteSelecionado, revistaSelecionada, DateTime.Now);

            repositorioEmprestimo.RegistrarEmprestimo(novoEmprestimo);

            Notificador.ExibirMensagem("O registro foi concluído com sucesso!", ConsoleColor.Green);
        }

        public void RegistrarDevolucao()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Registrando devolução...");
            Console.WriteLine("-------------------------");
            Console.WriteLine();

            VisualizarEmprestimos(false);

            Console.WriteLine();
            Console.Write("Digite o ID do empréstimo que deseja registrar a devolução: ");

            int id = Convert.ToInt32(Console.ReadLine());

            Emprestimo emprestimo = repositorioEmprestimo.SelecionarPorId(id);

            bool devolucaoRegistrada = emprestimo.RegistrarDevolucao(DateTime.Now);

            if (devolucaoRegistrada == false)
                Notificador.ExibirMensagem("Data de devolução inválida", ConsoleColor.Red);

            Notificador.ExibirMensagem("Devolução registrada com sucesso", ConsoleColor.Green);
        }

        public void VisualizarEmprestimos(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Visualizando empréstimos...");
                Console.WriteLine("---------------------------");
                Console.WriteLine();
            }

            Console.WriteLine("{0, -8} | {1, -12} | {2, -12} | {3, -10}",
                              "ID", "Cliente", "Data", "Revista");           

            Emprestimo[] emprestimos = repositorioEmprestimo.SelecionarEmprestimos();

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo e = emprestimos[i];

                if (e == null)
                    continue;

                Console.WriteLine("{0, -8} | {1, -12} | {2, -12} | {3, -10}",
                    e.Id, e.Cliente.Nome, e.DataEmprestimo, e.Revista.Titulo);
            }

        }

    }
}
