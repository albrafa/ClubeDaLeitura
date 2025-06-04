using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class Emprestimo : EntidadeBase<Emprestimo>
{    
    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataDevolucao { get; private set; }


    public Emprestimo(Amigo amigo, Revista revista, DateTime dataEmprestimo)
    {
        Amigo = amigo;
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

    public override string Validar()
    {
        string erros = null;

        if (Amigo == null)
            erros += "O campo 'Amigo' é obrigatório.\n";

        if (Revista == null)
            erros += "O campo 'Revista' é obrigatório.\n";

        if (DataEmprestimo == DateTime.MinValue)
            erros += "O campo 'Data de Emprestimo' é obrigatório.\n";

        return erros;
    }

    public override void AtualizarDados(Emprestimo registroEditado)
    {        
    }
}
