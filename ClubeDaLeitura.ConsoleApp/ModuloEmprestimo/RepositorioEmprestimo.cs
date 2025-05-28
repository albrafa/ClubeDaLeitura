using ClubeDaLeitura.ConsoleApp.ModuloCliente;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class RepositorioEmprestimo
    {
        public Emprestimo[] emprestimos = new Emprestimo[100];  //quando no caso de devolução, usar o contador negativo (--)
        public int contadorEmprestimos = 0;


        public void RegistrarEmprestimo(Emprestimo novoEmprestimo)

        {
            novoEmprestimo.Id = GeradorIds.GerarIdEmprestimo();
            
            emprestimos[contadorEmprestimos++] = novoEmprestimo;
        }

        public Emprestimo[] SelecionarEmprestimo()
        {
            return emprestimos;
        }

        internal Emprestimo SelecionarEmprestimoPorId(int idSelecionado)
        {
            for (int i = 0;
        }
    }
}
