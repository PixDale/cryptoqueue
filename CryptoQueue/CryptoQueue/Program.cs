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

            do{
                Console.WriteLine("Escolha uma opção:\n[1] - Criptografa uma Mensagem.\n[2] - Descriptografar uma Mensagem.\n[3] - Sair\nEscolha: ");
            op = Convert.ToInt32(Console.ReadLine());
            switch(op) {
                case 1:
                    Console.WriteLine("Digite a Mensagem: ");
                    mensagem = Console.ReadLine();
                    Console.WriteLine("Digite a letra inicial sequencia Chave (A~Z): ");
                    do
                    {
                        chave = Console.ReadLine()[0]; //Retorna a primeira letra da string
                        if(chave >= 'a' && chave <= 'z') // Faz um toUpper na letra
                        {
                            chave = (char)((int)chave - 32);
                        }
                    } while (chave < 'A' || chave > 'Z');

                   Console.WriteLine("Digite o caminho para salvar a mensagem criptografada: ");
                   string cam = Console.ReadLine();

                    string msg = Funcoes.Criptografar(mensagem, chave, cam);
                    Console.WriteLine(msg);

                    break;
             case 2:
                    Console.WriteLine("Digite o caminho do arquivo da mensagem criptografada: ");
                    string caminho = Console.ReadLine();
                    Console.WriteLine("Digite a letra inicial sequencia Chave (A~Z): ");
                    do
                    {
                        chave = Console.ReadLine()[0]; //Retorna a primeira letra da string
                        if(chave >= 'a' && chave <= 'z') // Faz um toUpper na letra
                        {
                            chave = (char)((int)chave - 32);
                        }
                    } while (chave < 'A' || chave > 'Z');

                    string result = Funcoes.Descriptografar(caminho, chave);
                        Console.WriteLine(result);

                    break;
             case 4:
                        
                string teste = "C:/Users/Matheus/Desktop/msgCriptografada.txt";
                string msg1 = "OLA MUNDO";
                string cripto = Funcoes.Criptografar(msg1, 65,"C:/Users/Matheus/Desktop");
                string teste2 = System.IO.File.ReadAllText(teste);
                        Console.WriteLine("---ARQ---"+teste2);
                        Console.WriteLine("---RESULT"+cripto);
                        if(cripto.Equals(teste2)){
                            Console.WriteLine("TRUE");
                        } else  
                            Console.WriteLine("FALSE");
                string decript = Funcoes.Descriptografar(teste, 65);
                        Console.WriteLine(decript);
break;
                }
                
            } while(op != 3);

            

            



            //msg.ToList().ForEach(Console.Write);


        }
    }
}
