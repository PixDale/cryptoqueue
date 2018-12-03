using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o tamanho da Fila: ");
            int tamanhoFila = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a letra inicial sequencia Chave (A~Z): ");
            Char chave;
            do
            {
                chave = Console.ReadLine()[0]; //Retorna a primeira letra da string
                if(chave >= 'a' && chave <= 'z') // Faz um toUpper na letra
                {
                    chave = (char)((int)chave - 32);
                }
            } while (chave < 'A' || chave > 'Z');
            

            FilaCircular filaTeste = new FilaCircular();
            filaTeste.Adicionar('A');
            filaTeste.Adicionar('B');
            filaTeste.Adicionar('C');
            filaTeste.Adicionar('D');
            filaTeste.Adicionar('E');
            Console.WriteLine(filaTeste.Items());
            Console.WriteLine(filaTeste.getNode(0));
            Console.WriteLine(filaTeste.getNode(1));
            Console.WriteLine(filaTeste.getNode(2));
            Console.ReadKey();

            string teste = Funcoes.Criptografar("ALI@ABOOD", (uint)tamanhoFila, chave);
            string testeconv = Funcoes.DecToFibFormat(12);
            Console.WriteLine("\n"+testeconv);
            uint testeconv2 = Funcoes.FibToDecFormat((uint)Convert.ToInt32(testeconv));
            Console.WriteLine(testeconv2);
            Console.ReadKey();
        }
    }
}
