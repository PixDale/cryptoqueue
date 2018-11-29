using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaM1Lista
{
    //Implementar lista circular duplamente ligada.
    public class ListaCircular
    {
        private Node fim;
        private int size=0;
        public ListaCircular()
        {
            fim = null;
        }
        public bool isEmpty()
        {
            return fim == null;
        }
        public void inicializarLista(String x)
        {
            Node aux = new Node();
            aux.Info = x;
            fim = aux;
            fim.Next = fim;
            fim.Back = fim;
            size++;
        }

        //Adicionar o item ao final da lista.
        public void Adicionar(String item)
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
        public string[] Items()
        {
            string[] listaItems = new string[size];
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
            return null;
        }

    }
}
