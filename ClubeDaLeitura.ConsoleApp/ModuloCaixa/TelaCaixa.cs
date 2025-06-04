using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using System;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa

{
    public class TelaCaixa : TelaBase<Caixa>
    {
        public RepositorioCaixa repositorioCaixa;

        public TelaCaixa(RepositorioCaixa rCaixa)
        {
            repositorioCaixa = rCaixa;
            repositorioBase = rCaixa;
            Modulo = "Caixa";
        }                           
      
        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0, -8} | {1, -15} | {2, -10} | {3, -10} | {4, -20}",
                                 "ID Caixa", "Etiqueta", "Cor", "Status", "Revistas da Caixa");
        }

        protected override void ApresentarLinhaTabela(Caixa caixa)
        {        
            Console.WriteLine("{0, -8} | {1, -15} | {2, -10} | {3, -10} | {4, -20}",
                caixa.Id, caixa.EtiquetaCaixa, caixa.CorCaixa, caixa.DiasEmprestimoCaixa, caixa.ObterQuantidadeRevista());

        }

        protected override Caixa ObterDados()
        {
            Console.Write("Digite o texto da etiqueta da caixa: ");
            string etiquetaCaixa = Console.ReadLine();

            Console.Write("Selecione a cor da caixa: ");
            string corCaixa = Console.ReadLine();

            Console.Write("Dias em que a caixa será emprestada (padrão: 7 dias): ");
            int diasEmprestimoCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa novaCaixa = new Caixa(etiquetaCaixa, corCaixa, diasEmprestimoCaixa);

            return novaCaixa;
        }
    }
}