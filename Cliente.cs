using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Cliente
    {
        private int id;
        private string nome;
        private string email;
        private ListaProdutos compras;

        public Cliente(int id, string nome, string email)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.compras = new ListaProdutos();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public ListaProdutos Compras
        {
            get { return compras; }
        }

        public void AdicionarCompra(Produto produto)
        {
            compras.AdicionarUltimaPosicao(produto);
        }

        public void ExibirCompras()
        {
            Console.WriteLine($"Compras do Cliente {nome}: \n");
            foreach (var produto in compras)
            {
                produto.ExibirDetalhes();
            }
        }
    }
}
