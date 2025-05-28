using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{

    public class Revista
    {
        public static int RevistaSelecionada = 0;
        private string caixaPertencente;

        public int IdRevista { get; set; }
        public string TituloRevista { get; set; }
        public int NumeroRevista { get; set; }
        public int AnoPublicacao { get; set; }
        public Caixa CaixaPertencente { get; set; }        

        public string NumeroSerie
        {
            get
            {
                string tresPrimeirosCaracteres = TituloRevista.Substring(0, 3).ToUpper();

                return $"{tresPrimeirosCaracteres}-{IdRevista}";
            }
        }


        public Revista(string tituloRevista, int numeroRevista, int anoPublicacao, Caixa caixaPertencente)
        {
            TituloRevista = tituloRevista;
            NumeroRevista = numeroRevista;
            AnoPublicacao = anoPublicacao;
            CaixaPertencente = caixaPertencente;
        }

        public Revista(string tituloRevista, int numeroRevista, int anoPublicacao, string caixaPertencente)
        {
            TituloRevista = tituloRevista;
            NumeroRevista = numeroRevista;
            AnoPublicacao = anoPublicacao;
            this.caixaPertencente = caixaPertencente;
        }

        public int HistoricoEmprestimosRevista()
        {
            RevistaSelecionada++;

            return RevistaSelecionada;
        }

        public string Validar()
        {
            string erros = null;

            if (string.IsNullOrEmpty(TituloRevista))
                erros += "O campo 'Título' é obrigatório.";

            if (TituloRevista.Length < 2)
                erros += "Por favor, insira ao menos 2 caracteres.\n";

            if (NumeroRevista == null)
                erros += "O campo 'Número da Edição' é obrigatório.\n";

            if (AnoPublicacao == null)
                erros += "O campo 'Ano de Punlicação' é obrigatório.\n";

            if (caixaPertencente == null)
                erros += "O campo 'Caixa Pertencente' é obrigatório.\n";

            return erros;

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
        }
    }
}
