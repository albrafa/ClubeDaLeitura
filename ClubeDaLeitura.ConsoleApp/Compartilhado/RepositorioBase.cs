using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class RepositorioBase
    {
        public int contadorRegistros = 0;

        //public List<EntidadeBase> registros = new List<EntidadeBase>();
        public EntidadeBase[] registros = new EntidadeBase[100];

        public void CadastrarRegistro(EntidadeBase novoRegistro)
        {
            
            contadorRegistros++;

            novoRegistro.Id = contadorRegistros; 

            registros[contadorRegistros] = novoRegistro;
        }

        public bool EditarRegistro(int idSelecionado, EntidadeBase registroEditado)
        {
            bool conseguiuEditar = false;

            for (int i = 0; i < registros.Length; i++)
            {
                EntidadeBase registro = registros[i];

                if (registro == null) continue;

                else if (registro.Id == idSelecionado)
                {
                    registro.AtualizarDados(registroEditado);//

                    conseguiuEditar = true;
                }
            }

            return conseguiuEditar;
        }

        public bool ExcluirRegistro(int idSelecionado)
        {
            bool conseguiuExcluir = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null) continue;

                else if (registros[i].Id == idSelecionado)
                {
                    registros[i] = null;

                    conseguiuExcluir = true;
                }
            }

            return conseguiuExcluir;
        }

        public EntidadeBase SelecionarPorId(int idSelecionado)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                EntidadeBase registro = registros[i];

                if (registro == null)
                    continue;

                else if (registro.Id == idSelecionado)
                    return registro;
            }

            return null;
        }

        public EntidadeBase[] SelecionarRegistros()
        {
            return registros;
        }
    }
}
