using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace _01.IDisposable
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(3000); //aguarda 3 segundos
            for (long i = 0; i < 100000000000; i++)
            {
                Livro l = new Livro();
                await Task.Delay(3); //aguarda 3 milissegundos
            }

            Console.ReadKey();
        }
    }

    class Livro
    {
        string[] palavras = new string[1000000];
    }

    //<image url="$(ProjectDir)\img1.png"/>
}
