using System;
using System.Threading.Tasks;

namespace _03.Coleta
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(3000); //aguarda 3 segundos

            await GerarTiposValor();

            //await GerarTiposReferencia();
            //Quando são gerados muitos objetos,
            //a imagem abaixo mostra que a quantidade de memória alocada
            //aumenta bastante após 3 segundos, mas se mantém estável, pois
            //nesse momento o coletor de lixo age para 
            //liberar os objetos que deixaram de ser utilizados
            //<image url="$(ProjectDir)\img2.png"/>

            Console.ReadKey();
        }

        private static async Task GerarTiposValor()
        {
            for (long i = 0; i < 100000000000; i++)
            {
                byte nivelDeAzul = 0xFF; // == System.Byte 
                int populacao = 1500; // System.Int32 
                short passageirosVoo = 230; // System.Int16 
                long populacaoDoBrasil = 207_660_929; // System.Int64 

                sbyte nivelDeBrilho = 127; // System.Sbyte 
                uint estoque = 1500; // System.UInt32 
                ushort passageirosNavio = 230; // System.UInt16 
                ulong populacaoDoMundo = 7_000_000_000; // System.UInt64 

                bool fumante = false; // System.Boolean booleano
                decimal salario = 5000m; // System.Decimal 
                double massaDaTerra = 5.9736e24; // System.Double
                float numeroPI = 3.14159f; // System.Single
                await Task.Delay(3); //aguarda 3 milissegundos
            }

            //a imagem abaixo mostra que a quantidade de memória alocada
            //não varia significativamente
            //<image url="$(ProjectDir)\img1.png"/>
        }

        private static async Task GerarTiposReferencia()
        {
            for (long i = 0; i < 100000000000; i++)
            {
                Livro l = new Livro();
                await Task.Delay(3); //aguarda 3 milissegundos
            }
        }
    }

    class Livro
    {
        string[] palavras = new string[1000000];

        ~Livro()
        {
            //O finalizador é invocado pelo coletor de lixo

            //Aqui o livro deve ser finalizado
            Console.WriteLine("Finalizador chamado...");

            //Sabotando o coletor de lixo...
            //Assim, o número de lixo sem ser coletado se acumula...

            //CUIDADO AO HABILITAR O COMANDO SLEEP ABAIXO!
            //Thread.Sleep(100);

            //Note que agora a memória ocupada cresce absurdamente
            //quando atrasamos a execução do coletor de lixo...
            //<image url="$(ProjectDir)\img3.png"/>

        }
    }
}
