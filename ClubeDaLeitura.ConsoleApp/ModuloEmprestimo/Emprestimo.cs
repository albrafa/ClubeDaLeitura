using ClubeDaLeitura.ConsoleApp.ModuloCliente;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class Emprestimo
{
    public int Id;
    public Cliente Cliente { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataDevolucao { get; private set; }


    public Emprestimo(Cliente cliente, Revista revista, DateTime dataEmprestimo)
    {
        Cliente = cliente;
        Revista = revista;
        DataEmprestimo = DateTime.Today;
    }

    public int TempoCorridoEmprestimo()
    {
        TimeSpan tempoTotalEmprestimo = DateTime.Now.Subtract(DataEmprestimo);

        return tempoTotalEmprestimo.Days;
    }

    public bool RegistrarDevolucao(DateTime data)
    {
        if (data > DataEmprestimo)
        {
            DataDevolucao = data;
            return true;
        }

        return false;
    }
}
