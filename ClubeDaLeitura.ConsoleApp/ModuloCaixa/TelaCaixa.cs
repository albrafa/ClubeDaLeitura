using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using System;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa

{
    public class TelaCaixa : TelaBase
    {
        public RepositorioCaixa repositorioCaixa;

        public TelaCaixa(RepositorioCaixa rCaixa)
        {
            repositorioCaixa = rCaixa;
            Modulo = "Caixa";
        }
       
        public void CadastrarCaixa()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Cadastrando caixa...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            Console.Write("Digite o texto da etiqueta da caixa: ");
            string etiquetaCaixa = Console.ReadLine();

            Console.Write("Selecione a cor da caixa: ");
            string corCaixa = Console.ReadLine();

            Console.Write("Dias em que a caixa será emprestada (padrão: 7 dias): ");
            int diasEmprestimoCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa novaCaixa = new Caixa(etiquetaCaixa, corCaixa, diasEmprestimoCaixa);
            novaCaixa.Id = GeradorIds.GerarIdCaixa();

            repositorioCaixa.CadastrarRegistro(novaCaixa);

            Notificador.ExibirMensagem("A caixa foi cadastrada com sucesso!", ConsoleColor.Green);
        }

        public void EditarCaixa()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Editando Caixa...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarRegistros(false);

            Console.WriteLine("Digite o ID da caixa que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o texto da etiqueta da caixa: ");
            string etiquetaCaixa = Console.ReadLine()!.Trim();

            Console.Write("Selecione a cor da caixa: ");
            string corCaixa = Console.ReadLine()!.Trim();

            Console.Write("Dias em que a caixa será emprestada (padrão: 7 dias): ");
            int diasEmprestimoCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa novaCaixa = new Caixa(etiquetaCaixa, corCaixa, diasEmprestimoCaixa);

            bool conseguiuEditar = repositorioCaixa.EditarRegistro(idSelecionado, novaCaixa);


            if (!conseguiuEditar)
            {
                Notificador.ExibirMensagem("Houve um erro durante a edição das informações da caixa...", ConsoleColor.Red);
                return;
            }
            
            Notificador.ExibirMensagem("As informações da caixa foram editadas com sucesso!", ConsoleColor.Green);
        }


        public void ExcluirCaixa()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Excluindo caixa...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarRegistros(false);

            Console.WriteLine();
            Console.Write("Digite o ID da caixa que deseja excluir: ");

            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioCaixa.ExcluirRegistro(idSelecionado);

            if (!conseguiuExcluir)
            {
                Notificador.ExibirMensagem("Houve um erro durante a exclusão da caixa...", ConsoleColor.Red);
            }

            Notificador.ExibirMensagem("A caixa foi devidamente excluída do sistema!", ConsoleColor.Green);
        }
      
        protected override void ApresentarCabecalhoTabela()
        {
            Console.WriteLine("{0, -8} | {1, -15} | {2, -10} | {3, -10} | {4, -20}",
                                 "ID Caixa", "Etiqueta", "Cor", "Status", "Revistas da Caixa");
        }

        protected override void ApresentarLinhaTabela(EntidadeBase registro)
        {
            Caixa caixa = (Caixa)registro;

            Console.WriteLine("{0, -8} | {1, -15} | {2, -10} | {3, -10} | {4, -20}",
                caixa.Id, caixa.EtiquetaCaixa, caixa.CorCaixa, caixa.DiasEmprestimoCaixa, caixa.ObterQuantidadeRevista());

        }
    }
}