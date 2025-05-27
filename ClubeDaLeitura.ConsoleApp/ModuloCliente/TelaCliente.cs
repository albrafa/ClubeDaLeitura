using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCliente
{
    public class TelaCliente
    {
        public RepositorioCliente repositorioCliente;  
        
        public TelaCliente(RepositorioCliente rCliente)
        {
            repositorioCliente = rCliente;
        }

        public string ApresentarMenuCliente()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Gestão de Clientes");
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

            repositorioCliente.CadastrarCliente(novoCliente);

            Notificador.ExibirMensagem("O cliente foi cadastrado com sucesso!", ConsoleColor.Green);
        }
        public void EditarCliente()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Editando cliente...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarClientes(false);

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

            bool conseguiuEditar = repositorioCliente.EditarCliente(idSelecionado, novoCliente);

            if (!conseguiuEditar)
            {
                Notificador.ExibirMensagem("Houve um erro durante a edição das informações do cliente...", ConsoleColor.Red);
                return;
            }            

            Notificador.ExibirMensagem("As informações do cliente foram editadas com sucesso!", ConsoleColor.Green);        
        }

        public void ExcluirCliente()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Excluindo cliente...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarClientes(false);

            Console.Write("Digite o ID do cliente que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioCliente.ExcluirCliente(idSelecionado);

            if (!conseguiuExcluir)
            {
                Notificador.ExibirMensagem("Houve um erro durante a exclusão do cliente...", ConsoleColor.Red);
            }
            Console.WriteLine();

            Notificador.ExibirMensagem("O cliente foi devidamente excluído do sistema.", ConsoleColor.Green);
        }

        public void VisualizarClientes(bool exibirTitulo)
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

            Console.WriteLine("{0, -8} | {1, -12} | {2, -12} | {3, -10}",
                               "ID", "Nome", "Responsável", "Contato");

            Cliente[] clientes = repositorioCliente.SelecionarClientes();

            for (int i = 0; i < clientes.Length; i++)
            {
                Cliente clienteSelecionado = clientes[i];

                if (clienteSelecionado == null) continue;


                Console.WriteLine("{0, -8} | {1, -12} | {2, -12} | {3, -10}",
                clienteSelecionado.Id, clienteSelecionado.Nome, clienteSelecionado.NomeResponsavel, clienteSelecionado.Telefone);
            }
        }

    }
}
