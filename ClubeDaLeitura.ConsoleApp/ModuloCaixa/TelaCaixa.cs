using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using System;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa

{
    public class TelaCaixa
    {
        public RepositorioCaixa repositorioCaixa;
        public TelaCaixa(RepositorioCaixa repositorioCaixa)
        {
            repositorioCaixa = new RepositorioCaixa();
        }


        public string ApresentarMenuCaixa()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Gestão de caixas");
            Console.WriteLine("------------------");
            Console.WriteLine();
            Console.WriteLine("Escolha a operação desejada: ");
            Console.WriteLine("1 - Cadastrar nova caixa: ");
            Console.WriteLine("2 - Editar uma caixa já registrada: ");
            Console.WriteLine("3 - Excluir caixa: ");
            Console.WriteLine("4 - Visualizar caixa: ");

            string menuCaixa = Console.ReadLine();

            return menuCaixa;
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
            novaCaixa.IdCaixa = GeradorIds.GerarIdCaixa();

            repositorioCaixa.CadastrarCaixa(novaCaixa);

            Notificador.ExibirMensagem("A caixa foi cadastrada com sucesso!", ConsoleColor.Green);
        }

        public void EditarCaixa()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Editando Caixa...");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            VisualizarCaixa(false);

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

            bool conseguiuEditar = repositorioCaixa.EditarCaixa(idSelecionado, novaCaixa);


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

            VisualizarCaixa(false);

            Console.WriteLine();
            Console.Write("Digite o ID da caixa que deseja excluir: ");

            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = repositorioCaixa.ExcluirCaixa(idSelecionado);

            if (!conseguiuExcluir)
            {
                Notificador.ExibirMensagem("Houve um erro durante a exclusão da caixa...", ConsoleColor.Red);
            }

            Notificador.ExibirMensagem("A caixa foi devidamente excluída do sistema!", ConsoleColor.Green);
        }

        public void VisualizarCaixa(bool exibirMenu)
        {
            if (exibirMenu)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Visualizando Caixas...");
                Console.WriteLine("----------------------");
                Console.WriteLine();
            }

            Console.WriteLine("{0, -8} | {1, -15} | {2, -10} | {3, -10} | {4, -20}",
                                 "ID Caixa", "Etiqueta", "Cor", "Status", "Revistas da Caixa");

            Caixa[] caixaCadastrda = repositorioCaixa.SelecionarCaixa();

            for (int i = 0; i < caixaCadastrda.Length; i++)
            {
                Caixa caixaSelecionada = caixaCadastrda[i];

                if (caixaSelecionada == null) continue;

                Console.WriteLine("{0, -8} | {1, -15} | {2, -10} | {3, -10} | {4, -20}",
caixaSelecionada.IdCaixa, caixaSelecionada.EtiquetaCaixa, caixaSelecionada.CorCaixa, caixaSelecionada.DiasEmprestimoCaixa, caixaSelecionada.ObterQuantidadeRevista());

            }

        }

    }
}