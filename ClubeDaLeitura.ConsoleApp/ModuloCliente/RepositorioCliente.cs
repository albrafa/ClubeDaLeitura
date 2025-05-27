using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloCliente
{
    public class RepositorioCliente
    {
        public Cliente[] clientes = new Cliente[100];
        public int contadorClientes = 0;

        public void CadastrarCliente(Cliente novoCliente)
        {            
            novoCliente.Id = GeradorIds.GerarIdCliente();
            clientes[contadorClientes++] = novoCliente;            
        }

        public bool EditarCliente(int idSelecionado, Cliente clienteAtualizado)
        {
            bool conseguiuEditar = false;

            for (int i = 0; i < clientes.Length; i++)
            {
                if (clientes[i] == null) continue;

                else if (clientes[i].Id == idSelecionado)
                {
                    clientes[i].Nome = clienteAtualizado.Nome;
                    clientes[i].NomeResponsavel = clienteAtualizado.NomeResponsavel;
                    clientes[i].Telefone = clienteAtualizado.Telefone;

                    conseguiuEditar = true;
                }
            }

            return conseguiuEditar;
        }

        public bool ExcluirCliente(int idSelecionado)
        {
            bool conseguiuExcluir = false;

            for (int i = 0; i < clientes.Length; i++)
            {
                if (clientes[i] == null) continue;

                else if (clientes[i].Id == idSelecionado)
                {
                    clientes[i] = null;

                    conseguiuExcluir = true;
                }
            }

            return conseguiuExcluir;
        }

        public Cliente[] SelecionarClientes()
        {
            return clientes;
        }

        public Cliente SelecionarClientePorId(int idClienteSelecionado)
        {
            for (int i = 0; i < clientes.Length; i++)
            {
                Cliente cliente = clientes[i];

                if (cliente == null)
                    continue;

                else if (cliente.Id == idClienteSelecionado)
                    return cliente;
            }

            return null;
        }

    }
}
