using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoQueue
{
    abstract class Funcoes
    {

        public static uint Fib(uint n)
        {
            if(n < 2)
                return 1;
            else
            {
                return Fib(n - 1) + Fib(n - 2);
            }
        }
        public int ConverteBinFib()
        {
            //Implementar conversor de binario para formato fibonacci
            return 0;
        }
        public int ConverteFibBin()
        {
            //Implementar conversor de formato fibonacci para binario
            return 0;
        }
        public static  String  FibFormat (uint num)
        {
            IList<uint> numerosFib = new List<uint>();
            uint posicaoFib = 1;
            uint fibNumAtual = Fib(posicaoFib);

            do
            {
                numerosFib.Add(fibNumAtual);
                fibNumAtual = Fib(++posicaoFib);
            } while (fibNumAtual <= num);

            uint aux = num;
            String result = "";

            foreach (uint n in numerosFib.Reverse())
            {
                if(n <= aux)
                {
                    result += "1";
                    aux -= n;
                } else
                {
                    result += "0";
                }
            }
            //string resultInverso = new string(result.Reverse().ToArray());
            return result;           
        }

        public static string Criptografar(string msg, uint tam, uint giro)
        {
            FilaCircular filaChave = new FilaCircular();
            FilaCircular filaMensagem = new FilaCircular();
            FilaCircular filaXorada = new FilaCircular();

            //Preencher a fila chave com as letras do alfabeto
            for(int i=0, aux=0; i<tam; i++, aux++)
            {
                if(aux > 26)
                {
                    aux = 0;
                }
                filaChave.Adicionar((Char)(65+aux));
            }

            //Prencher a fila mensagem com a msg
            for(int i=0; i<msg.Length; i++)
            {
                filaMensagem.Adicionar(msg[i]);
            }
            Console.WriteLine(filaChave.Items());
            Console.WriteLine(filaMensagem.Items());

            //Preencher a fila Xorada com o XOR das filas Mensagem e Chave
            for(int i=0; i<tam; i++)
            {
                int letra = (int)filaChave.getNode(i) ^ (int)filaMensagem.getNode(i);

                filaXorada.Adicionar((Char)letra);
            }
            Console.WriteLine(filaXorada.Items());
            Console.WriteLine("\n"+filaXorada.ItemsToInt());

            return null;
        }

    }
}
