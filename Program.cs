using System;

namespace teste
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidadorString teste = new ValidadorString();

            Console.WriteLine(teste.Validar("[ (1) ]"));
        }
    }
}
