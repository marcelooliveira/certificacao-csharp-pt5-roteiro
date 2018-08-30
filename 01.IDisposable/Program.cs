using System;
using System.Diagnostics;

namespace _01.IDisposable
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();

            Third t = new Third();
            Console.ReadKey();
        }

        public class Cliente
        {
            public Cliente()
            {
                ClasseComFinalizador obj = new ClasseComFinalizador();
                obj.MostrarDuracao();
            }
        }

        public class ClasseComFinalizador
        {
            Stopwatch sw;

            public ClasseComFinalizador()
            {
                sw = Stopwatch.StartNew();
                Console.WriteLine("Objeto instanciado.");
            }

            public void MostrarDuracao()
            {
                Console.WriteLine("A instância {0} existe há {1} milissegundos.",
                                  this.GetType(), sw.Elapsed.TotalMilliseconds);
            }

            ~ClasseComFinalizador()
            {
                Console.WriteLine("Finalizando o objeto");
                sw.Stop();
                Console.WriteLine("A instância {0} existiu por {1} milissegundos.",
                                  this.GetType(), sw.Elapsed.TotalMilliseconds);
            }
        }
    }

    class First
    {
        ~First()
        {
            System.Diagnostics.Trace.WriteLine("First's destructor is called.");
        }
    }

    class Second : First
    {
        ~Second()
        {
            System.Diagnostics.Trace.WriteLine("Second's destructor is called.");
        }
    }

    class Third : Second
    {
        ~Third()
        {
            System.Diagnostics.Trace.WriteLine("Third's destructor is called.");
        }
    }

    /* Output (to VS Output Window):
        Third's destructor is called.
        Second's destructor is called.
        First's destructor is called.
    */
}
