using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloCliente;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections.Concurrent;

TelaPrincipal telaPrincipal = new TelaPrincipal();

RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
RepositorioCliente repCliente = new RepositorioCliente();
RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
RepositorioRevista repositorioRevista = new RepositorioRevista();

TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);

TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioCaixa, repCliente, repositorioRevista);

TelaCliente telaCliente = new TelaCliente(repCliente);

telaEmprestimo.telaCliente = telaCliente;
telaEmprestimo.telaRevista = telaRevista;

TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);



telaCliente.repositorioCliente = repCliente;





while (true)

{
    char opcaoEscolhida = telaPrincipal.ApresentarMenuPrincipal();

    switch (opcaoEscolhida)
    {
        case '1':
            string menuCliente = telaCliente.ApresentarMenuCliente();

            switch (menuCliente)
            {
                case "1":
                    telaCliente.CadastrarCliente(); break;
                case "2":
                    telaCliente.EditarCliente(); break;
                case "3":
                    telaCliente.ExcluirCliente(); break;
                case "4":
                    telaCliente.VisualizarCliente(true); break;
            }
            break;

        case '2':
            {
                string menuCaixa = telaCaixa.ApresentarMenuCaixa();

                switch (menuCaixa)
                {
                    case "1":
                        telaCaixa.CadastrarCaixa(); break;
                    case "2":
                        telaCaixa.EditarCaixa(); break;
                    case "3":
                        telaCaixa.ExcluirCaixa(); break;
                    case "4":
                        telaCaixa.VisualizarCaixa(true); break;
                }
            }
            break;

        case '3':
            {
                string menuRevista = telaRevista.ApresentarMenuRevista();

                switch (menuRevista)
                {
                    case "1":
                        telaRevista.CadastrarRevista(); break;
                    case "2":
                        telaRevista.EditarRevista(); break;
                    case "3":
                        telaRevista.ExcluirRevista(); break;
                    case "4":
                        telaRevista.VisualizarRevista(true); break;
                }
                break;
            }

        case '4':
            {
                string menuEmprestimo = telaEmprestimo.ApresentarMenuEmprestimo();

                switch (menuEmprestimo)
                {
                    case "1":
                        telaEmprestimo.RegistrarEmprestimo(); break;
                    case "2":
                        telaEmprestimo.RegistrarDevolucao(); break;
                    case "3":
                        telaEmprestimo.VisualizarEmprestimo(); break;
                }
                break;
            }

        default:
            {
                Console.WriteLine("Saindo do programa..."); break;
            }
    }
    Console.ReadLine();
}
