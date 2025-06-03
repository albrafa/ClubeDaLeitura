using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCompartilhado
{
    public class Notificador
    {
            public static void ExibirMensagem(string mensagem, ConsoleColor cor)
            {
                Console.ForegroundColor = cor;

                Console.WriteLine();

                Console.WriteLine(mensagem);

                Console.ResetColor();

                Console.ReadLine();
            }
    }
}
