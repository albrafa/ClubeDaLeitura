using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo : TelaBase<Amigo>
    {
        public RepositorioAmigo repositorioAmigo;  
        
        public TelaAmigo(RepositorioAmigo rAmigo)
        {
            repositorioAmigo = rAmigo;
            repositorioBase = rAmigo;

            Modulo = "Amigo";
        }                    

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0, -8} | {1, -12} | {2, -12} | {3, -10}",
                               "ID", "Nome", "Responsável", "Contato");
        }

        protected override void ApresentarLinhaTabela(Amigo amigoSelecionado)
        {            
            Console.WriteLine("{0, -8} | {1, -12} | {2, -12} | {3, -10}",
                amigoSelecionado.Id, amigoSelecionado.Nome, amigoSelecionado.NomeResponsavel, amigoSelecionado.Telefone);
        }

        protected override Amigo ObterDados()
        {
            Console.Write("Digite o nome do amigo: ");
            string nomeAmigo = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone para contato: ");
            int telefone = Convert.ToInt32(Console.ReadLine());

            Amigo novoAmigo = new Amigo(nomeAmigo, nomeResponsavel, telefone);

            return novoAmigo;
        }
    }
}
