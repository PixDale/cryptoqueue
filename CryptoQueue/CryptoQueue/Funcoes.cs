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
        public static  String  DecToFibFormat (uint num)
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
        public static uint FibToDecFormat(uint num)
        {
            uint result = 0;
            uint indiceFibAtual = 1;
            uint fibAtual = Fib(indiceFibAtual);
            string numBinario = Convert.ToString(num, 2);
            uint aux;
            for(int i = numBinario.Length-1; i > 0; i--)
            {
                aux = (uint)(numBinario[i] - '0');
                result += (aux * Fib((uint)i));
            }



            return result;
        }

        public static string Criptografar(string msg, uint tam, int chave)
        {
            FilaCircular filaChave = new FilaCircular();
            FilaCircular filaMensagem = new FilaCircular();
            int[] vetorXored = new int[tam];
            FilaCircular filaMsgCriptografada = new FilaCircular();

            //Preencher a fila chave com as letras do alfabeto
            for(int i=0, aux=0; i<tam; i++, aux++)
            {
                if(aux > 25)
                {
                    aux = 0;
                }
                filaChave.Adicionar((Char)(65+aux));
            }
            int giro = chave - 65;
            filaChave.Girar(giro);

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

                vetorXored[i]= letra;
            }
            int[] vetorXoredFib = new int[tam];
            for(int i=0; i<tam; i++)
            {
                vetorXoredFib[i] = Convert.ToInt32(DecToFibFormat((uint)vetorXored[i]), 2);
            }
            foreach(int i in vetorXoredFib)
            {
                filaMsgCriptografada.Adicionar((Char)i);
            }
            Console.WriteLine(filaMsgCriptografada.Items());

            return Convert.ToString(filaMsgCriptografada.Items());
        }
        public static string Descriptografar(string msg, uint tam, int chave)
        {




            return null;
        }

    }
}
