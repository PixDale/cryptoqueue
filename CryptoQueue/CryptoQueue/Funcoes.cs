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

        public static  uint  DecToFibFormat (uint num)
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
            uint saida = Convert.ToUInt32(result, 2);
            return saida;           
        }

        public static uint FibToDecFormat(uint num)
        {
            uint result = 0;
            uint indiceFibAtual = 1;
            uint fibAtual = Fib(indiceFibAtual);
            string numBinario = Convert.ToString(num, 2);
            for(int i = numBinario.Length-1, j=1, aux=0; i >= 0; i--, j++)
            {
                aux = numBinario[i] - '0';
                result += (uint)(aux * Fib((uint)j));
            }
            return result;
        }

        public static int[] Criptografar(string msg, uint tam, int chave)
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


            //Preencher o vetor Xored com o XOR das filas Mensagem e Chave
            for(int i=0; i<tam; i++)
            {
                int letra = (int)filaChave.getNode(i) ^ (int)filaMensagem.getNode(i);

                vetorXored[i]= letra;
            }
            uint[] vetorXoredFib = new uint[tam];
            for(int i=0; i<tam; i++)
            {
                vetorXoredFib[i] = DecToFibFormat((uint)vetorXored[i]);
            }
            foreach(int i in vetorXoredFib)
            {
                filaMsgCriptografada.Adicionar((Char)i);
            }
            int[] result = new int[tam];
            for (int i = 0; i< tam; i++)
            {
                result[i] = filaMsgCriptografada.getNode(i);
            }
            return result;
        }

        public static string Descriptografar(int[] msg, uint tam, int chave)
        {
            FilaCircular filaChave = new FilaCircular();
            FilaCircular filaMsgCriptografada = new FilaCircular();
            int[] vetorXored = new int[tam];
            int[] vetorDesXored = new int[tam];
            Console.WriteLine("TAM = " + tam + " - MSG LENGTH = " + msg.Length);

            //Preencher a fila chave com as letras do alfabeto
            for (int i = 0, aux = 0; i < tam; i++, aux++)
            {
                if (aux > 25)
                {
                    aux = 0;
                }
                filaChave.Adicionar((Char)(65 + aux));
            }
            int giro = chave - 65;
            filaChave.Girar(giro);

            //Voltar cada elemento da mensagem do formato Fibonacci para o formato Decimal
            for (int i = 0; i < tam; i++)
            {
                vetorXored[i] = (int)FibToDecFormat((uint)msg[i]);
            }
            //Fazer o Xor de cada elemento do vetor Xored com a fila chave para recuperar a letra original
            for (int i = 0; i < tam; i++)
            {
                int letra = (int)filaChave.getNode(i) ^ vetorXored[i];

                vetorDesXored[i] = letra;
            }
            FilaCircular mensagemFinal = new FilaCircular();
            foreach(int i in vetorDesXored)
            {
                mensagemFinal.Adicionar((char)i);
            }
            return new string(mensagemFinal.Items());
        }

    }
}
