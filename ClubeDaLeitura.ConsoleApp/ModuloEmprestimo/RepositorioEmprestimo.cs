using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloCliente;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

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

        public Emprestimo[] SelecionarEmprestimos()
        {
            return emprestimos;
        }

        public Emprestimo SelecionarPorId(int id)
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo emprestimo = emprestimos[i];

                if (emprestimo == null)
                    continue;

                else if (emprestimo.Id == id)
                    return emprestimo;
            }

            return null;
        }
    }
}
