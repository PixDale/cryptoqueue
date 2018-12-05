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
            


            int[] msg = Funcoes.Criptografar("ALI@ABOOD", (uint)tamanhoFila, chave);

            string result = Funcoes.Descriptografar(msg, (uint)tamanhoFila, chave);

            msg.ToList().ForEach(Console.Write);

            string teste = "OLAOLAOLA";

            Console.WriteLine("\n\nresult==" + result);
            Console.WriteLine("\n\nresult==" + teste);
            Console.ReadKey();
        }
    }
}
