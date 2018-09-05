using System;
using System.Diagnostics;

namespace _01._1.Finalizador
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        for (int i = 0; i < 100; i++)
    //        {
    //            Primeiro obj = new Primeiro();
    //        }
    //        GC.Collect();
    //        Console.ReadKey();
    //    }
    //}

    //class Primeiro
    //{
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        for (int i = 0; i < 100; i++)
    //        {
    //            Primeiro obj = new Primeiro();
    //        }
    //        GC.Collect();
    //        Console.ReadKey();
    //    }
    //}

    //class Primeiro
    //{
    //    protected static int NumeroInstancias = 1;

    //    public int IdInstancia { get; set; }

    //    public Primeiro()
    //    {
    //        IdInstancia = NumeroInstancias;
    //        NumeroInstancias++;
    //    }

    //    ~Primeiro()
    //    {
    //        System.Diagnostics.Trace.WriteLine(IdInstancia + " - Primeiro finalizador foi chamado.");
    //    }
    //}




    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                //Primeiro obj = new Primeiro();
                Terceiro obj = new Terceiro();
            }
            //Força uma coleta de lixo imediata de todas as gerações.
            GC.Collect();
            Console.ReadKey();
        }
    }

    class Primeiro
    {
        protected static int NumeroInstancias = 1;

        public int IdInstancia { get; set; }

        public Primeiro()
        {
            IdInstancia = NumeroInstancias;
            NumeroInstancias++;
        }

        ~Primeiro()
        {
            System.Diagnostics.Trace.WriteLine(IdInstancia + " - Primeiro finalizador foi chamado.");
        }
    }

    class Segundo : Primeiro
    {
        ~Segundo()
        {
            System.Diagnostics.Trace.WriteLine(IdInstancia + " - Segundo finalizador foi chamado.");
        }
    }

    class Terceiro : Segundo
    {
        ~Terceiro()
        {
            System.Diagnostics.Trace.WriteLine(IdInstancia + " - Terceiro finalizador foi chamado.");
        }
    }
}
