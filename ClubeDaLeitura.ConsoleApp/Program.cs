using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp
{
    #region exemplo com veiculos

    public class VeiculoBase : object
    {
        public string modelo = "";
        public int velocidadeAceleracao = 0;
        public int velocidadeAtual = 0;
        public int velocidadeMaxima = 0;

        public virtual void Acelerar()
        {
            if (velocidadeAtual < velocidadeMaxima)
                velocidadeAtual += velocidadeAceleracao;
        }
    }

    public class Carro : VeiculoBase
    {
        public Carro(string modeloCarro)
        {
            modelo = modeloCarro;
            velocidadeMaxima = 150;
            velocidadeAceleracao = 30;
        }

        public override void Acelerar()
        {
            base.Acelerar();
            Console.WriteLine("O carro está andando...");
        }
    }

    public class Bicicleta : VeiculoBase
    {
        public Bicicleta(string modeloBicicleta)
        {
            modelo = modeloBicicleta;
            velocidadeMaxima = 60;
            velocidadeAceleracao = 10;
        }

        public override void Acelerar()
        {
            base.Acelerar();
            Console.WriteLine("A bicicleta anda...");
            Console.WriteLine("E faz bem pra tua saúde");
        }
    }

    public class Moto : VeiculoBase
    {
        public Moto(string modeloMoto)
        {
            modelo = modeloMoto;
            velocidadeMaxima = 120;
            velocidadeAceleracao = 20;
        }

        public override void Acelerar()
        {
            base.Acelerar();
            MostrarInformacoes();
            Console.WriteLine($"A moto {modelo} está andando...");
            Console.WriteLine("A moto faz um barulho infernal...");
        }

        private void MostrarInformacoes()
        {
            Console.WriteLine("Modelo: " + modelo  );
            Console.WriteLine("Velocidade Atual: " + velocidadeAtual);
        }
    }

    #endregion
    internal class Program
    {
        #region exemplo com veiculos
        static void Main2(string[] args)
        {
            

            Carro veiculo1 = new Carro("Nissan Kicks");
            veiculo1.Acelerar();

            Bicicleta veiculo2 = new Bicicleta("Caloi Cross");
            veiculo2.Acelerar();

            Moto veiculo3 = new Moto("CB 500");
            veiculo3.Acelerar();

            Moto veiculo4 = new Moto("Twister");
            veiculo4.Acelerar();
        }
        #endregion

        static void Main(string[] args)
        {                                        
            Amigo amigo = new Amigo("Leonardo", "Leonardo Pai", 987);
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            repositorioAmigo.CadastrarRegistro(amigo);
            repositorioAmigo.CadastrarRegistro(new Amigo("Rafael", "Carolina", 499997654));

            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);            

            Caixa caixa = new Caixa("123-abc", "Vermelho", 7);
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            repositorioCaixa.CadastrarRegistro(caixa);            
            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
            

            RepositorioRevista repositorioRevista = new RepositorioRevista();
            repositorioRevista.CadastrarRegistro(new Revista("Superman 2", 2, 2020, caixa));
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
            

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioCaixa, repositorioAmigo, repositorioRevista);

            telaEmprestimo.telaAmigo = telaAmigo;
            telaEmprestimo.telaRevista = telaRevista;

            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                char opcaoEscolhida = telaPrincipal.ApresentarMenuPrincipal();

                switch (opcaoEscolhida)
                {
                    case '1':
                        string menuAmigo = telaAmigo.ApresentarMenu();

                        switch (menuAmigo)
                        {
                            case "1":
                                telaAmigo.CadastrarAmigo(); break;
                            case "2":
                                telaAmigo.EditarAmigo(); break;
                            case "3":
                                telaAmigo.ExcluirAmigo(); break;
                            case "4":
                                telaAmigo.VisualizarRegistros(true); break;
                        }
                        break;

                    case '2':
                        {
                            string menuCaixa = telaCaixa.ApresentarMenu();

                            switch (menuCaixa)
                            {
                                case "1":
                                    telaCaixa.CadastrarCaixa(); break;
                                case "2":
                                    telaCaixa.EditarCaixa(); break;
                                case "3":
                                    telaCaixa.ExcluirCaixa(); break;
                                case "4":
                                    telaCaixa.VisualizarRegistros(true); break;
                            }
                        }
                        break;

                    case '3':
                        {
                            string menuRevista = telaRevista.ApresentarMenu();

                            switch (menuRevista)
                            {
                                case "1":
                                    telaRevista.CadastrarRevista(); break;
                                case "2":
                                    telaRevista.EditarRevista(); break;
                                case "3":
                                    telaRevista.ExcluirRevista(); break;
                                case "4":
                                    telaRevista.VisualizarRegistros(true); break;
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
                                    telaEmprestimo.VisualizarEmprestimos(true); break;
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