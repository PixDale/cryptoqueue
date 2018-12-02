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
            Console.WriteLine("Digite o giro da Fila Chave: ");
            int giro = Convert.ToInt32(Console.ReadLine());

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

            string teste = Funcoes.Criptografar("OLA MUNDO", 20, 3);
            Console.ReadKey();
        }
    }
}
