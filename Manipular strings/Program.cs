using System;
using System.Collections.Generic;
using System.Text;

namespace Manipular_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
