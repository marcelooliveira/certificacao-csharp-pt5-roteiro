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
            //builder = new StringBuilder();
            //using (StringWriter writer = new StringWriter(builder))
            //{
            //    for (int i = 0; i < materias.Length; i++)
            //    {
            //        string materia = materias[i];
            //        if (i > 0)
            //        {
            //            writer.Write(", ");
            //        }
            //        writer.Write(materia);
            //        Console.WriteLine(writer);
            //    }
            //}


            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<livro>" +
                        "  <titulo>Orientação a Objetos</titulo>" +
                        "  <preco>69.90</preco>" +
                        "</livro>");

            XmlNode newElem = doc.CreateNode("element", "autor", "");
            newElem.InnerText = "Thiago Leite e Carvalho";

            XmlElement root = doc.DocumentElement;
            root.AppendChild(newElem);

            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                doc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();

                //using (var stringReader = new StringReader(stringWriter.GetStringBuilder().ToString()))
                //using (var xmlTextReader = XmlReader.Create(stringReader))
                //{
                //    string line;
                //    while (xmlTextReader.Read() != null)
                //    {

                //    }
                //}
            }


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
