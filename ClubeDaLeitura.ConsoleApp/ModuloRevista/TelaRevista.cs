using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using System;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class TelaRevista : TelaBase
    {
        public TelaCaixa TelaCaixa;

        public RepositorioCaixa repositorioCaixa;
        public RepositorioRevista repositorioRevista;

        public TelaRevista(RepositorioRevista repRevista, RepositorioCaixa repCaixa)
        {
            repositorioRevista = repRevista;
            repositorioCaixa = repCaixa;
            Modulo = "Revista";
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

            Caixa caixaPertencente = (Caixa)repositorioCaixa.SelecionarPorId(idCaixa);

            Revista novaRevista = new Revista(tituloRevista, numeroRevista, anoPublicacao, caixaPertencente);
            novaRevista.Id = GeradorIds.GerarIdRevista();

            repositorioRevista.CadastrarRegistro(novaRevista);

            Notificador.ExibirMensagem("A revista foi cadastrada com sucesso!", ConsoleColor.Green);
        }

        public void EditarRevista()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Editando Revistas...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarRegistros(false);

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

            Caixa caixaPertencente = (Caixa)repositorioCaixa.SelecionarPorId(idCaixa);

            Revista novaRevista = new Revista(tituloRevista, numeroRevista, anoPublicacao, caixaPertencente);

            bool conseguiuEditar = repositorioRevista.EditarRegistro(idSelecionado, novaRevista);

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

            VisualizarRegistros(false);

            Console.Write("Digite o ID da revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioRevista.ExcluirRegistro(idSelecionado);

            if (!conseguiuExcluir)
            {
                Notificador.ExibirMensagem("Houve um erro durante a exclusão da revista...", ConsoleColor.Red);
            }

            Notificador.ExibirMensagem("A revista foi devidamente excluída do sistema.", ConsoleColor.Green);
        }
       
        public void VisualizarCaixas()
        {
            Caixa[] caixas = (Caixa[])repositorioCaixa.SelecionarRegistros();

            foreach (Caixa c in caixas)
            {
                if (c != null)
                    Console.WriteLine(c.Id + " - " + c.CorCaixa + " - " + c.EtiquetaCaixa);
            }

            Console.ReadLine();
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            Revista r = (Revista)registro;            

            Console.WriteLine("{0, -8} | {1, -15} | {2, -8} | {3, -8} | {4, -8}",
                r.Id, r.Titulo, r.Numero, r.AnoPublicacao, r.CaixaPertencente.EtiquetaCaixa);
        }

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0, -8} | {1, -15} | {2, -8} | {3, -8} | {4, -8}",
                           "ID", "Título", "Número", "Ano Publicação", "Caixa");
        }
    }
}

