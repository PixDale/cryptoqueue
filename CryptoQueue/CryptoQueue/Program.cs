using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoQueue
{
    class Program
    {
        static void Main(string[] args)
        {

            string mensagem;
            Char chave;
            int tamanho;
            int op = 0;
            Stream inStream = Console.OpenStandardInput(1024);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, 1024));

            do
            {
                Console.WriteLine("Escolha uma opção:\n[1] - Criptografa uma Mensagem.\n[2] - Descriptografar uma Mensagem.\n[3] - Sair\nEscolha: ");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Digite a Mensagem: ");
                        mensagem = Console.ReadLine();
                        Console.WriteLine("Digite o tamanho da fila Chave, valor minimo: " + mensagem.Length);
                        do
                        {
                            tamanho = Convert.ToInt32(Console.ReadLine());
                            if (tamanho < mensagem.Length)
                                Console.WriteLine("Valor Invalido, digite novamente:");
                        } while (tamanho < 0 || tamanho < mensagem.Length);
                        int aux;
                        if (tamanho > 25)
                            aux = 25;
                        else
                        {
                            aux = tamanho-1;
                        }
                        Console.WriteLine("Digite a letra inicial sequencia Chave (A~" + (Char)('A'+aux)+")");
                        do
                        {
                            chave = Console.ReadLine()[0]; //Retorna a primeira letra da string
                            if (chave >= 'a' && chave <= 'a' + tamanho-1) // Faz um toUpper na letra
                            {
                                chave = (char)((int)chave - 32);
                            }
                        } while (chave < 'A' || chave > 'A' + tamanho-1);
                        

                        string msg = Funcoes.Criptografar(mensagem, chave, tamanho);
                        Console.WriteLine("Copie sua mensagem criptografada:\n");
                        Console.WriteLine(msg);
                        break;
                    case 2:
                        Console.WriteLine("Digite a mensagem criptografada: ");
                        string mensagemCriptografada = Console.ReadLine();
                        Console.WriteLine("Digite a letra inicial sequencia Chave: ");
                        do
                        {
                            chave = Console.ReadLine()[0]; //Retorna a primeira letra da string
                            if (chave >= 'a' && chave <= 'z') // Faz um toUpper na letra
                            {
                                chave = (char)((int)chave - 32);
                            }
                        } while (chave < 'A' || chave > 'Z');

                        string result = Funcoes.Descriptografar(mensagemCriptografada, chave);
                        Console.WriteLine("\nMensagem Descriptografada: \n");
                        Console.WriteLine(result);
                        Console.WriteLine("\n");
                        break;
                }

            } while (op != 3);

        }

    }
}
