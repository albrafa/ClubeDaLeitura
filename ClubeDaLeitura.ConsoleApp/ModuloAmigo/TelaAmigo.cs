using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo : TelaBase
    {
        public RepositorioAmigo repositorioAmigo;  
        
        public TelaAmigo(RepositorioAmigo rAmigo)
        {
            repositorioAmigo = rAmigo;
            Modulo = "Amigo";
        }
       

        public void CadastrarAmigo()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Cadastrando amigo...");
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.Write("Digite o nome do amigo: ");
            string nomeAmigo = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone para contato: ");
            int telefone = Convert.ToInt32(Console.ReadLine());

            Amigo novoAmigo = new Amigo(nomeAmigo, nomeResponsavel, telefone);

            repositorioAmigo.CadastrarRegistro(novoAmigo);

            Notificador.ExibirMensagem("O amigo foi cadastrado com sucesso!", ConsoleColor.Green);
        }
        public void EditarAmigo()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Editando amigo...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write("Digite o ID de registro do amigo que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o nome do amigo: ");
            string nomeAmigo = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone para contato: ");
            int telefone = Convert.ToInt32(Console.ReadLine());

            Amigo novoAmigo = new Amigo(nomeAmigo, nomeResponsavel, telefone);

            bool conseguiuEditar = repositorioAmigo.EditarRegistro(idSelecionado, novoAmigo);

            if (!conseguiuEditar)
            {
                Notificador.ExibirMensagem("Houve um erro durante a edição das informações do amigo...", ConsoleColor.Red);
                return;
            }            

            Notificador.ExibirMensagem("As informações do amigo foram editadas com sucesso!", ConsoleColor.Green);        
        }

        public void ExcluirAmigo()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Excluindo amigo...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarRegistros(false);

            Console.Write("Digite o ID do amigo que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioAmigo.ExcluirRegistro(idSelecionado);

            if (!conseguiuExcluir)
            {
                Notificador.ExibirMensagem("Houve um erro durante a exclusão do amigo...", ConsoleColor.Red);
            }
            Console.WriteLine();

            Notificador.ExibirMensagem("O amigo foi devidamente excluído do sistema.", ConsoleColor.Green);
        }

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0, -8} | {1, -12} | {2, -12} | {3, -10}",
                               "ID", "Nome", "Responsável", "Contato");
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            Amigo amigoSelecionado = (Amigo)registro;

            Console.WriteLine("{0, -8} | {1, -12} | {2, -12} | {3, -10}",
                amigoSelecionado.Id, amigoSelecionado.Nome, amigoSelecionado.NomeResponsavel, amigoSelecionado.Telefone);
        }

    }
}
