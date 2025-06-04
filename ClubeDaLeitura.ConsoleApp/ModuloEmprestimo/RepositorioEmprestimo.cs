using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class RepositorioEmprestimo : RepositorioBase<Emprestimo>
{
    public void RegistrarEmprestimo(Emprestimo novoEmprestimo)
    {
        base.CadastrarRegistro(novoEmprestimo);
    }       
}
