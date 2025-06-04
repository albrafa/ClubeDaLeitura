using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class TelaBase<T> where T : EntidadeBase<T>
{
    public string Modulo;
    public RepositorioBase<T> repositorioBase;

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

    public void CadastrarRegistro()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine($"Cadastrando {Modulo}...");
        Console.WriteLine("----------------------");
        Console.WriteLine();        

        T novoRegistro = this.ObterDados();

        repositorioBase.CadastrarRegistro(novoRegistro);

        Notificador.ExibirMensagem("O cadastrado foi realizado com sucesso!", ConsoleColor.Green);
    }

    public void EditarRegistro()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine($"Editando {Modulo}...");
        Console.WriteLine("----------------------");
        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o ID de registro que deseja editar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        T novoRegistro = this.ObterDados();

        bool conseguiuEditar = repositorioBase.EditarRegistro(idSelecionado, novoRegistro);

        if (!conseguiuEditar)
        {
            Notificador.ExibirMensagem("Houve um erro durante a edição das informações...", ConsoleColor.Red);
            return;
        }

        Notificador.ExibirMensagem("As informações foram editadas com sucesso!", ConsoleColor.Green);
    }

    public void ExcluirRegistro()
    {
        Console.Clear();
        Console.WriteLine("----------------------");
        Console.WriteLine($"Excluindo {Modulo}...");
        Console.WriteLine("----------------------");
        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja excluir: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioBase.ExcluirRegistro(idSelecionado);

        if (!conseguiuExcluir)
        {
            Notificador.ExibirMensagem("Houve um erro durante a exclusão...", ConsoleColor.Red);
        }

        Console.WriteLine();

        Notificador.ExibirMensagem("O registro foi devidamente excluído do sistema.", ConsoleColor.Green);
    }

    protected abstract T ObterDados();   

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

        T[] registros = repositorioBase.SelecionarRegistros();

        foreach (T registro in registros)
        {
            if (registro == null)
                continue;

            ApresentarLinhaTabela(registro);
        }
    }

    protected abstract void ApresentarLinhaTabela(T registro);

    protected abstract void ApresentarCabecalhoTabela();
    
}
