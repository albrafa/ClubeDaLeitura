using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using System;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class TelaRevista
    {
        public TelaCaixa TelaCaixa;

        public RepositorioCaixa repositorioCaixa;
        public RepositorioRevista repositorioRevista;

        public TelaRevista(RepositorioRevista repRevista, RepositorioCaixa repCaixa)
        {
            repositorioRevista = repRevista;
            repositorioCaixa = repCaixa;
        }

        public string ApresentarMenuRevista()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Gestão de revistas");
            Console.WriteLine("------------------");
            Console.WriteLine();
            Console.WriteLine("Escolha a operação desejada: ");
            Console.WriteLine("1 - Cadastrar nova revista: ");
            Console.WriteLine("2 - Editar uma revista já cadastrada: ");
            Console.WriteLine("3 - Excluir revista: ");
            Console.WriteLine("4 - Visualizar revistas: ");

            string menuRevista = Console.ReadLine();

            return menuRevista;
        }

        public void CadastrarRevista()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Cadastrando revista...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            Console.Write("Digite o título da revista: ");
            string tituloRevista = Console.ReadLine()!.Trim();

            Console.Write("Digite o número da edição da revista: ");
            int numeroRevista = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe o ano de publicação da revista");
            int anoPublicacao = Convert.ToInt32(Console.ReadLine());

            VisualizarCaixas();

            Console.Write("Informe o id da caixa");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa caixaPertencente = repositorioCaixa.SelecionarCaixaPorId(idCaixa);

            Revista novaRevista = new Revista(tituloRevista, numeroRevista, anoPublicacao, caixaPertencente);
            novaRevista.Id = GeradorIds.GerarIdRevista();

            repositorioRevista.CadastrarRevista(novaRevista);

            Notificador.ExibirMensagem("A revista foi cadastrada com sucesso!", ConsoleColor.Green);
        }

        public void EditarRevista()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Editando Revistas...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarRevistas(false);

            Console.Write("Digite o ID da revista que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o título da revista: ");
            string tituloRevista = Console.ReadLine()!.Trim();

            Console.Write("Digite o número da edição da revista: ");
            int numeroRevista = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe o ano de publicação da revista");
            int anoPublicacao = Convert.ToInt32(Console.ReadLine());

            VisualizarCaixas();

            Console.Write("Informe o id da caixa");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa caixaPertencente = repositorioCaixa.SelecionarCaixaPorId(idCaixa);

            Revista novaRevista = new Revista(tituloRevista, numeroRevista, anoPublicacao, caixaPertencente);

            bool conseguiuEditar = repositorioRevista.EditarRevista(idSelecionado, novaRevista);

            if (!conseguiuEditar)
            {
                Notificador.ExibirMensagem("Houve um erro durante a edição das informações...", ConsoleColor.Red);
                return;
            }            

            Notificador.ExibirMensagem("A revista foi editada com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirRevista()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Exlcuindo revista...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarRevistas(false);

            Console.Write("Digite o ID da revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioRevista.ExcluirRevista(idSelecionado);

            if (!conseguiuExcluir)
            {
                Notificador.ExibirMensagem("Houve um erro durante a exclusão da revista...", ConsoleColor.Red);
            }

            Notificador.ExibirMensagem("A revista foi devidamente excluída do sistema.", ConsoleColor.Green);
        }

        public void VisualizarRevistas(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Visualizando Revistas...");
                Console.WriteLine("----------------------");
                Console.WriteLine();
            }

            Console.WriteLine("{0, -8} | {1, -15} | {2, -8} | {3, -8} | {4, -8}",
                              "ID", "Título", "Número", "Ano Publicação", "Caixa");

            Revista[] revistas = repositorioRevista.SelecionarRevista();

            for (int i = 0; i < revistas.Length; i++)
            {
                Revista r = revistas[i];

                if (r == null) continue;

                Console.WriteLine("{0, -8} | {1, -15} | {2, -8} | {3, -8} | {4, -8}",
                    r.Id, r.Titulo, r.Numero, r.AnoPublicacao, r.CaixaPertencente.EtiquetaCaixa);

            }
        }

        public void VisualizarCaixas()
        {
            Caixa[] caixas = repositorioCaixa.SelecionarTodasCaixas();

            foreach (Caixa c in caixas)
            {
                if (c != null)
                    Console.WriteLine(c.IdCaixa + " - " + c.CorCaixa + " - " + c.EtiquetaCaixa);
            }

            Console.ReadLine();
        }

    }
}

