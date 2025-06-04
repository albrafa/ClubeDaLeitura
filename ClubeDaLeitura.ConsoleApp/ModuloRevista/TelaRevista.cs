using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using System;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class TelaRevista : TelaBase<Revista>
    {
        public TelaCaixa TelaCaixa;

        public RepositorioCaixa repositorioCaixa;
        public RepositorioRevista repositorioRevista;

        public TelaRevista(RepositorioRevista repRevista, RepositorioCaixa repCaixa)
        {
            repositorioRevista = repRevista;
            repositorioCaixa = repCaixa;
            repositorioBase = repRevista;

            Modulo = "Revista";
        }                    
        
        public void VisualizarCaixas()
        {
            Caixa[] caixas = repositorioCaixa.SelecionarRegistros();

            foreach (Caixa c in caixas)
            {
                if (c != null)
                    Console.WriteLine(c.Id + " - " + c.CorCaixa + " - " + c.EtiquetaCaixa);
            }

            Console.ReadLine();
        }

        protected override void ApresentarLinhaTabela(Revista r)
        {
            Console.WriteLine("{0, -8} | {1, -15} | {2, -8} | {3, -8} | {4, -8}",
                r.Id, r.Titulo, r.Numero, r.AnoPublicacao, r.CaixaPertencente.EtiquetaCaixa);
        }

        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0, -8} | {1, -15} | {2, -8} | {3, -8} | {4, -8}",
                           "ID", "Título", "Número", "Ano Publicação", "Caixa");
        }

        protected override Revista ObterDados()
        {
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

            return novaRevista;
        }

    }
}

