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

            string mensagem;
            Char chave;
            int op = 0;

            do
            {
                Console.WriteLine("Escolha uma opção:\n[1] - Criptografa uma Mensagem.\n[2] - Descriptografar uma Mensagem.\n[3] - Sair\nEscolha: ");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Digite a Mensagem: ");
                        mensagem = Console.ReadLine();
                        Console.WriteLine("Digite a letra inicial sequencia Chave (A~Z): ");
                        do
                        {
                            chave = Console.ReadLine()[0]; //Retorna a primeira letra da string
                            if (chave >= 'a' && chave <= 'z') // Faz um toUpper na letra
                            {
                                chave = (char)((int)chave - 32);
                            }
                        } while (chave < 'A' || chave > 'Z');

                        string msg = Funcoes.Criptografar(mensagem, chave);
                        Console.WriteLine("Copie sua mensagem criptografada:\n");
                        Console.WriteLine(msg);
                        break;
                    case 2:
                        Console.WriteLine("Digite a mensagem criptografada: ");
                        string mensagemCriptografada = Console.ReadLine();
                        Console.WriteLine("Digite a letra inicial sequencia Chave (A~Z): ");
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
