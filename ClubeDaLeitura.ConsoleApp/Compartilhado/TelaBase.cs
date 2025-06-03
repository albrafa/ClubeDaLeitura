using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class TelaBase
{
    public string Modulo;

    public string ApresentarMenu()
    {
        Console.WriteLine("------------------");
        Console.WriteLine($"Gestão de {Modulo} ");
        Console.WriteLine("------------------");

        Console.WriteLine();

        Console.WriteLine("Escolha a operação desejada: ");
        Console.WriteLine($"1 - Cadastrar novo {Modulo}: ");
        Console.WriteLine($"2 - Editar cadastro de {Modulo}: ");
        Console.WriteLine($"3 - Excluir cadastro de {Modulo}: ");
        Console.WriteLine($"4 - Visualizar {Modulo}s: ");

        string menuAmigo = Console.ReadLine();

        return menuAmigo;
    }

    public void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine($"Visualizando {Modulo}...");
            Console.WriteLine("----------------------");
            Console.WriteLine();
        }

        Console.WriteLine();

        ApresentarCabecalhoTabela();

        RepositorioBase repositorioBase = new RepositorioBase();    

        EntidadeBase[] registros = repositorioBase.SelecionarRegistros();

        foreach (EntidadeBase registro in registros)
        {
            if (registro == null)
                continue;

            ApresentarLinhaTabela(registro);
        }
    }

    protected abstract void ApresentarLinhaTabela(EntidadeBase registro);

    protected abstract void ApresentarCabecalhoTabela();
    
}
