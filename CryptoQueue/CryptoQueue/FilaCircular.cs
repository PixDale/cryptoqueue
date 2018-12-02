using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoQueue
{
    //Implementar lista circular duplamente ligada.
    public class FilaCircular
    {
        private Node fim;
        private int size = 0;

        public FilaCircular()
        {
            fim = null;
        }
        public Char getNode(int indice)
        {
            if(indice <= size)
            {
                Node nodeaux = fim.Next;
                if (indice == 0)
                {
                    return nodeaux.Info;
                }
                for (int i = 1; i <= indice; i++)
                {
                    nodeaux = nodeaux.Next;
                }
                return nodeaux.Info;
            }
            else
            {
                return (char)20;
            }
            
        }
        public bool isEmpty()
        {
            return fim == null;
        }
        public int getSize()
        {
            return size;
        }
        public void inicializarLista(Char x)
        {
            Node aux = new Node();
            aux.Info = x;
            fim = aux;
            fim.Next = fim;
            fim.Back = fim;
            size++;
        }

        //Adicionar o item ao final da lista.
        public void Adicionar(Char item)
        {
            if(isEmpty()){
                inicializarLista(item);
            }
            else
            {
                Node aux = new Node();
                aux.Info = item;
                aux.Next = fim.Next;
                aux.Back = fim;
                fim.Next = aux;
                fim = aux;
                size++;
            }
        }

        //Remover o item da lista. Se o item não estiver na lista, ignorar.
        public void Remover()
        {
            if (isEmpty())
            {
                throw new Exception("Lista Vazia!");
            }
            Node aux = new Node();
            aux = fim.Next;
            Node prox, ant;
            prox = aux.Next;
            ant = aux.Back;
            prox.Back = ant;
            ant.Next = prox;
            size--;
            
        } // fecha remover

        //Girar a lista.
        public void Girar(int qtd)
        {
            if (qtd == 0)
            {
                return;
            }
            else if (qtd > 0)
            {
                for (int i = 0; i < qtd; i++)
                {
                    fim = fim.Next;
                }
            }
            else if (qtd < 0)
            {
                qtd *= -1;
                for (int i = 0; i < qtd; i++)
                {
                    fim = fim.Back;
                }
            }
        }

        //Retornar a lista de items da lista.
        public Char[] Items()
        {
            Char[] listaItems = new Char[size];
            Node aux = new Node();
            aux = fim.Next;

            if (isEmpty())
            {
                return null;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    listaItems[i] = aux.Info;
                    aux = aux.Next;
                }
                return listaItems;
            }
        }
        public int[] ItemsToInt()
        {
            int[] listaItems = new int[size];
            Node aux = new Node();
            aux = fim.Next;

            if (isEmpty())
            {
                return null;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    listaItems[i] = (int)aux.Info;
                    Console.Write(listaItems[i]+" - ");
                    aux = aux.Next;
                }
                return listaItems;
            }
        }

    }
}
