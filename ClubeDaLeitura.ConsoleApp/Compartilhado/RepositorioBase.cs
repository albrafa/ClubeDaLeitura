using ClubeDaLeitura.ConsoleApp.ModuloCompartilhado;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class RepositorioBase<T> where T : EntidadeBase<T>
{
    public int contadorRegistros = 0;
    
    public T[] registros = new T[100];

    public void CadastrarRegistro(T novoRegistro)
    {                        
        registros[contadorRegistros] = novoRegistro; 

        contadorRegistros++;
        novoRegistro.Id = contadorRegistros;
    }

    public bool EditarRegistro(int idSelecionado, T registroEditado)
    {
        bool conseguiuEditar = false;

        for (int i = 0; i < registros.Length; i++)
        {
            T registro = registros[i];

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

    public T SelecionarPorId(int idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            T registro = registros[i];

            if (registro == null)
                continue;

            else if (registro.Id == idSelecionado)
                return registro;
        }

        return null;
    }

    public T[] SelecionarRegistros()
    {
        return registros;
    }
}
