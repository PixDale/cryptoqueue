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

        public static string Criptografar(string msg, int chave)
        {
            int tam = msg.Length;
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
            string result = "";
            for (int i = 0; i < tam; i++)
            {
                result += filaMsgCriptografada.getNode(i);

            }
            Console.WriteLine("É PRA RETORNAR CHARES = "+result);
            System.IO.File.WriteAllText(caminho+"/msgCriptografada.txt", result);
            return result;
        }



        public static string Descriptografar(string msg, int chave)
        {
            int tam = msg.Length;
            FilaCircular filaChave = new FilaCircular();
            FilaCircular filaMsgCriptografada = new FilaCircular();
            int[] vetorXored = new int[tam];
            int[] vetorDesXored = new int[tam];

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

        static string ConsertaCaminho(string caminho){  
            string aux = "";
            foreach (char c in caminho) {
                if(c.Equals('\\')) {
                    aux += '/';
                } else {
                    aux += c;
                }
                if(aux[aux.Length-1].Equals('/')){
                    aux.Remove(aux.Length-1);
                }
            }
            return aux;
        }
}
}
