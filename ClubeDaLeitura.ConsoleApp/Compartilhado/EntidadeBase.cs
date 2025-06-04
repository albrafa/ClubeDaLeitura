namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class EntidadeBase<T>
{
    public int Id { get; set; }

    public abstract string Validar();

    public abstract void AtualizarDados(T registroEditado);
}
