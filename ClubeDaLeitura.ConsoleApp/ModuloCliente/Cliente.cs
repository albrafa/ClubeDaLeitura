using System.Linq.Expressions;

namespace ClubeDaLeitura.ConsoleApp.ModuloCliente
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeResponsavel { get; set; }
        public int Telefone { get; set; }


        public Cliente(string nomeCliente, string nomeResponsavel, int telefone)
        {
            Nome = nomeCliente;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
        }


        public string HistoricoEmprestimos()    //utilizar a revista que o usuário pegou emprestada e usar a aula Regras de Negócio 03
        {

            return "";
        }

        public string Validar ()
        {
           string erros = null;

            if (string.IsNullOrEmpty(Nome))
                erros += "O campo 'Nome' é obrigatório.\n";

            if (Nome.Length < 3)
                erros += "Por favor, insira ao menos 3 caracteres.\n";

            if (string.IsNullOrEmpty(NomeResponsavel))
                erros += "O campo 'Nome do Responsável' é obrigatório.\n";

            if (NomeResponsavel.Length < 3)
                erros += "Por favor, insira ao menos 3 caracteres.\n";

            if (Telefone == null)
                erros += "O campo 'Contato' é obrigatório";

            return erros;
        }
    }
}
