using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
  public  class Caixa
    {
        public int IdCaixa { get; set; }
        public string EtiquetaCaixa { get; set; }
        public string CorCaixa { get; set; }
        public int DiasEmprestimoCaixa { get; set; }
        public string CaixaPertencente { get; set; }

        public Revista[] Revistas;


        public Caixa(string etiquetaCaixa, string corCaixa, int diasEmprestimoCaixa, string caixaPertencente)
        {
            EtiquetaCaixa = etiquetaCaixa;
            CorCaixa = corCaixa;
            DiasEmprestimoCaixa = diasEmprestimoCaixa;
            CaixaPertencente = caixaPertencente;

            Revistas = new Revista[100];
        }

        public string Validar()
        {
            string erros = null;

            if (string.IsNullOrEmpty(EtiquetaCaixa))
                erros += "O campo 'Etiqueta' é obrigatório.\n";

            if (EtiquetaCaixa.Length < 2)
                erros += "Insira ao menos 2 caracteres.\n";

            if (string.IsNullOrEmpty(CorCaixa))
                erros += "O campo 'Cor da Caixa' é obrigatório.\n";

            if (DiasEmprestimoCaixa == null)
                erros += "O campo 'Tempo de empréstimo' é obrigatório.";

            return erros;
        }

        public void AdicionarRevista(Revista revista)
        {
            for (int i = 0; i < Revistas.Length; i++)
            {
                if (Revistas[i] == null)
                {
                    Revistas[i] = revista;
                    return;
                }
            }
        }

        public void RemoverRevista(Revista revista)
        {
            for(int i = 0; i <Revistas.Length; i++)
            {
                if (Revistas[i] == null)
                    continue;

                else if (Revistas[i] == revista)
                {
                    Revistas[i] = null;

                    return;
                }
            }

        }

        public int ObterQuantidadeRevista()
        {
            int contador = 0;

            for (int i = 0; i < Revistas.Length; i++)
            {
                if (Revistas[i] != null)
                    contador++;
            }

            return contador;
        }

    }


}
