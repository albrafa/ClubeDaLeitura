
namespace ClubeDaLeitura.ConsoleApp.ModuloCompartilhado
{
    public class TelaPrincipal
    {
        public char ApresentarMenuPrincipal()
        {

            Console.WriteLine("---------------------");
            Console.WriteLine("  CLUBE DA LEITURA");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            Console.WriteLine("Escolha a operação desejada: ");
            Console.WriteLine("1 - Gestão de amigos: ");
            Console.WriteLine("2 - Gestão de Caixas: ");
            Console.WriteLine("3 - Gestão de Revistas: ");
            Console.WriteLine("4 - Empréstimos e devoluções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }
    }
}