using System;
using System.Threading.Tasks;

namespace _03.Coleta
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Task.Delay(3000); //aguarda 3 segundos

            //await GerarTiposValor();

            await GerarTiposReferencia();
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
            for (long i = 0; i < 100; i++)
            {
                byte nivelDeAzul = 0xFF;
                int populacao = 1500;
                short passageirosVoo = 230;
                long populacaoDoBrasil = 207_660_929;

                sbyte nivelDeBrilho = 127;
                uint estoque = 1500;
                ushort passageirosNavio = 230;
                ulong populacaoDoMundo = 7_000_000_000;

                bool fumante = false;
                decimal salario = 5000m;
                double massaDaTerra = 5.9736e24;
                float numeroPI = 3.14159f;
                await Task.Delay(3);
            }

            //a imagem abaixo mostra que a quantidade de memória alocada
            //não varia significativamente
            //<image url="$(ProjectDir)\img1.png"/>
        }

        private static async Task GerarTiposReferencia()
        {
            for (long i = 0; i < 100; i++)
            {
                Livro livro = new Livro();
                await Task.Delay(3); //aguarda 3 milissegundos
            }
        }
    }

    class Livro
    {
        string[] palavras = new string[1000000];

        ~Livro()
        {
            //    //O finalizador é invocado pelo coletor de lixo

            //    //Aqui o livro deve ser finalizado
            //    Console.WriteLine("Finalizador chamado...");

            //    //Sabotando o coletor de lixo...
            //    //Assim, o número de lixo sem ser coletado se acumula...

            //    //CUIDADO AO HABILITAR O COMANDO SLEEP ABAIXO!
            //    //Thread.Sleep(100);

            //    //Note que agora a memória ocupada cresce absurdamente
            //    //quando atrasamos a execução do coletor de lixo...
            //    //<image url="$(ProjectDir)\img3.png"/>

        }
    }
}

