using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{

    public class Revista : EntidadeBase<Revista>
    {
        public static int RevistaSelecionada = 0;        
        public string Titulo { get; set; }
        public int Numero { get; set; }
        public int AnoPublicacao { get; set; }
        public Caixa CaixaPertencente { get; set; }        

        public string NumeroSerie
        {
            get
            {
                string tresPrimeirosCaracteres = Titulo.Substring(0, 3).ToUpper();

                return $"{tresPrimeirosCaracteres}-{Id}";
            }
        }

        public Revista(string tituloRevista, int numeroRevista, int anoPublicacao, Caixa caixaPertencente)
        {
            Titulo = tituloRevista;
            Numero = numeroRevista;
            AnoPublicacao = anoPublicacao;
            CaixaPertencente = caixaPertencente;
        }

        public int HistoricoEmprestimosRevista()
        {
            RevistaSelecionada++;

            return RevistaSelecionada;
        }

        public override string Validar()
        {
            string erros = null;

            if (string.IsNullOrEmpty(Titulo))
                erros += "O campo 'Título' é obrigatório.";

            if (Titulo.Length < 2)
                erros += "Por favor, insira ao menos 2 caracteres.\n";

            if (Numero == 0)
                erros += "O campo 'Número da Edição' é obrigatório.\n";

            if (AnoPublicacao == 0)
                erros += "O campo 'Ano de Punlicação' é obrigatório.\n";

            if (CaixaPertencente == null)
                erros += "O campo 'Caixa Pertencente' é obrigatório.\n";           

            return erros;
        }       

        public override void AtualizarDados(Revista revistaEditada)
        {            
            Titulo = revistaEditada.Titulo;
            Numero = revistaEditada.Numero;
            AnoPublicacao = revistaEditada.AnoPublicacao;
            CaixaPertencente = revistaEditada.CaixaPertencente;
        }

        //public void AdicionarCaixa(Caixa caixa)
        //{
        //    for (int i = 0; i < CaixaPertencente.Length; i++)
        //    {
        //        if (Caixas[i] == null)
        //        {
        //            Caixas[i] = caixa;
        //            return;
        //        }
        //    }

        //}

        //public void RemoverCaixa(Caixa caixa)
        //{
        //    for (int i = 0; i < CaixaPertencente.Length; i++)
        //    {
        //        if (Caixas[i] == null)
        //            continue;

        //        else if (Caixas[i] == caixa)
        //            Caixas[i] = null;
        //    }
        //}

        //public int ObterQuantidadeCaixa()
        //{
        //    int contador = 0;

        //    for (int i = 0; i < Caixas.Length; i++)
        //    {
        //        {
        //            if (Caixas[i] != null)
        //                contador++;
        //        }                
        //    }
        //    return contador;
        //}
    }
}
