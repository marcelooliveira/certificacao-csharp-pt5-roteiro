using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml;

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

            string[] materias = new string[] { "Português", "Matemática", "Geografia" };

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < materias.Length; i++)
            {
                string materia = materias[i];
                if (i > 0)
                {
                    builder.Append(", ");
                }
                builder.Append(materia);
                Console.WriteLine(builder);
            }

            Console.WriteLine();

            //var fileBuilder = new StringBuilder(File.ReadAllText("cadastro.txt"));

            string textoArquivo = File.ReadAllText("cadastro.txt");
            using (var reader = new StringReader(textoArquivo))
            {
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    Console.WriteLine(linha);
                }
            }

            Console.Clear();

            //string textoArquivo = File.ReadAllText("cadastro.txt");
            //using (var reader = new StringReader(textoArquivo))
            //{
            //    using (var writer = new StringWriter())
            //    {
            //        string linha;
            //        while ((linha = reader.ReadLine()) != null)
            //        {
            //            //Console.WriteLine(linha);
            //            writer.WriteLine(linha);
            //        }
            //        Console.WriteLine(writer);
            //    }
            //}

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
