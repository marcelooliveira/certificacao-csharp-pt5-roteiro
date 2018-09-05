using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Manipular_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //string materias = "";
            //materias = materias + "Português";
            //Console.WriteLine(materias);
            //materias = materias + ", Matemática";
            //Console.WriteLine(materias);
            //materias = materias + ", Geografia";
            //Console.WriteLine(materias);

            StringBuilder builder = new StringBuilder();
            builder.Append("Português");
            Console.WriteLine(builder);
            builder.Append(", Matemática");
            Console.WriteLine(builder);
            builder.Append(", Geografia");
            Console.WriteLine(builder);

            Console.ReadKey();
        }
    }

    public interface IFormatadorDeSaida<T>
    {
        string GetSaida(IEnumerator<T> iterador, int tamanhoRegistro);
    }

    public class Formatador : IFormatadorDeSaida<string>
    {
        readonly Func<int, char> sufixo = col => col % 2 == 0 ? '\n' : '\t';
        public string GetSaida(IEnumerator<string> iterador, int tamanhoRegistro)
        {
            var saida = new StringBuilder();
            for (int i = 1; iterador.MoveNext(); i++)
            {
                saida.Append(iterador.Current);
                saida.Append(sufixo(i));
            }
            return saida.ToString();
        }
    }
}
