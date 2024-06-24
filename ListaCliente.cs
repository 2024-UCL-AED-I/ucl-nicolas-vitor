using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class ListaClientes : IEnumerable<Cliente>
    {
        private NoCliente cabeca;
        private int qntElementos;

        public ListaClientes()
        {
            cabeca = null;
            qntElementos = 0;
        }

        public NoCliente GetCabeca()
        {
            return cabeca;
        }

        public void ImprimirLista()
        {
            NoCliente atual = cabeca;
            while (atual != null)
            {
                Console.WriteLine($"Cliente: {atual.Elemento.Nome}, Email: {atual.Elemento.Email}");
                atual.Elemento.ExibirCompras();
                atual = atual.Proximo;
            }
        }

        public void AdicionaPrimeiraPosicao(Cliente elemento)
        {
            NoCliente novoNo = new NoCliente(elemento);
            novoNo.Proximo = cabeca;
            cabeca = novoNo;
            qntElementos++;
        }

        public void AdicionarUltimaPosicao(Cliente elemento)
        {
            NoCliente novoNo = new NoCliente(elemento);
            if (cabeca == null)
            {
                cabeca = novoNo;
            }
            else
            {
                NoCliente atual = cabeca;
                while (atual.Proximo != null)
                {
                    atual = atual.Proximo;
                }
                atual.Proximo = novoNo;
            }
            qntElementos++;
        }

        public Cliente BuscarPorId(int id)
        {
            NoCliente atual = cabeca;
            while (atual != null)
            {
                if (atual.Elemento.Id == id)
                {
                    return atual.Elemento;
                }
                atual = atual.Proximo;
            }
            return null;
        }

        public void RemovePrimeiraPosicao()
        {
            if (cabeca == null)
            {
                Console.WriteLine("A lista está vazia. Não há elementos para remover.");
                return;
            }
            cabeca = cabeca.Proximo;
            qntElementos--;
        }

        public void RemoveUltimaPosicao()
        {
            if (cabeca == null)
            {
                Console.WriteLine("A lista está vazia. Não há elementos para remover.");
                return;
            }
            if (cabeca.Proximo == null)
            {
                cabeca = null;
                qntElementos--;
                return;
            }
            NoCliente anterior = null;
            NoCliente atual = cabeca;
            while (atual.Proximo != null)
            {
                anterior = atual;
                atual = atual.Proximo;
            }
            anterior.Proximo = null;
            qntElementos--;
        }

        public void RemoveNPosicao(int posicao)
        {
            if (posicao < 0 || posicao >= qntElementos)
            {
                Console.WriteLine("Posição inválida. Cancelando operação.");
                return;
            }
            if (posicao == 0)
            {
                cabeca = cabeca.Proximo;
            }
            else
            {
                NoCliente anterior = null;
                NoCliente atual = cabeca;
                for (int i = 0; i < posicao; i++)
                {
                    anterior = atual;
                    atual = atual.Proximo;
                }
                anterior.Proximo = atual.Proximo;
            }
            qntElementos--;
        }

        public IEnumerator<Cliente> GetEnumerator()
        {
            NoCliente atual = cabeca;
            while (atual != null)
            {
                yield return atual.Elemento;
                atual = atual.Proximo;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
