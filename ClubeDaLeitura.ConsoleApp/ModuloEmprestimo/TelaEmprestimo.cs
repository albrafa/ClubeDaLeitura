using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    class TelaEmprestimo
    {
        public RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioCaixa repositorioCaixa;
        public RepositorioAmigo repositorioAmigo;
        public RepositorioRevista repositorioRevista;

        public TelaAmigo telaAmigo;
        public TelaRevista telaRevista;

        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioCaixa repositorioCaixa,
            RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
            this.repositorioCaixa = repositorioCaixa;
            this.repositorioAmigo = repositorioAmigo;
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

            //visualizar a lista de amigos
            telaAmigo.VisualizarRegistros(false);

            //pegando o amigo
            Console.Write("Digite o ID do amigo: ");
            int idAmigoSelecionado = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarPorId(idAmigoSelecionado);

            telaRevista.VisualizarRegistros(false);

            Console.Write("Digite o ID da revista desejada: ");
            int idRevistaSelecionada = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            
            Revista revistaSelecionada = repositorioRevista.SelecionarPorId(idRevistaSelecionada);

            Emprestimo novoEmprestimo = new Emprestimo(amigoSelecionado, revistaSelecionada, DateTime.Now);

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
                              "ID", "Amigo", "Data", "Revista");           

            Emprestimo[] emprestimos = repositorioEmprestimo.SelecionarRegistros();

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo e = emprestimos[i];

                if (e == null)
                    continue;

                Console.WriteLine("{0, -8} | {1, -12} | {2, -12} | {3, -10}",
                    e.Id, e.Amigo.Nome, e.DataEmprestimo, e.Revista.Titulo);
            }

        }

    }
}
