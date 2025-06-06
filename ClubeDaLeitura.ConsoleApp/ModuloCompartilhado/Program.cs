﻿using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloCliente;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections.Concurrent;

namespace ClubeDaLeitura.ConsoleApp.ModuloCompartilhado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            RepositorioCliente repositorioCliente = new RepositorioCliente();
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

            TelaCliente telaCliente = new TelaCliente(repositorioCliente);
            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);            
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioCaixa, repositorioCliente, repositorioRevista);


            TelaPrincipal telaPrincipal = new TelaPrincipal();


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
        }
    }        
}