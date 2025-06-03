using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class EntidadeBase
{
    public int Id { get; set; }

    public abstract string Validar();

    public abstract void AtualizarDados(EntidadeBase registroEditado);
}
