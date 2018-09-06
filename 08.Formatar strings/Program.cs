using System;

namespace _08.Formatar_strings
{

    public class Program
    {
        public static void Main()
        {
            var deLorean = new DeLorean();
            Console.WriteLine(deLorean);
        }
    }

    class DeLorean
    {
        public CapacitorDeFluxo Capacitor { get; } = new CapacitorDeFluxo();

        public override string ToString()
        {
            return string.Format(
                "DeLorean DMC-12\r\n"
                + "===============\r\n"
                + "\r\n"
                + Capacitor);
        }
    }

    class CapacitorDeFluxo
    {
        public const double VELOCIDADE_MPH = 88; //milhas por hora
        public const double KMH_PARA_MPH = 1.60934; //fator de conversão para KMH

        public override string ToString()
        {
            return string.Format(
                "Capacitor de fluxo\r\n"
                + "=================\r\n"
                + "Velocidade mínima:\r\n"
                + "\tEm milhas por hora:      {0,10:N2} MPH\r\n"
                + "\tEm quilômetros por hora: {1,10:N2} KMH"
                , VELOCIDADE_MPH, VELOCIDADE_MPH * KMH_PARA_MPH);
        }
    }
}
