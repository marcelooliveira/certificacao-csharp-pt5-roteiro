using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ISet<Teste> novoSet = new HashSet<Teste>();
            novoSet.Add(new Teste() { nome = "Mama", idade = 1 });
            novoSet.Add(new Teste() { nome = "lala", idade = 2 });
            novoSet.Add(new Teste() { nome = "tata", idade = 3 });
            novoSet.Add(new Teste() { nome = "papa", idade = 4 });
            novoSet.Add(new Teste() { nome = "tata", idade = 3 });
            Console.WriteLine(string.Join(", ", novoSet));
            Console.ReadLine();
        }
    }

    class Teste
    {
        public string nome;
        public int idade;

        public override bool Equals(object obj)
        {
            var teste = obj as Teste;
            return teste != null &&
                   nome == teste.nome &&
                   idade == teste.idade;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nome, idade);
        }

        public override string ToString()
        {
            return nome + "-" + idade;
        }
    }
}
