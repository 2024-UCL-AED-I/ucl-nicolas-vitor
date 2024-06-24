using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Produto
    {
        private int id;
        private string nome;
        private double preco;
        private int quantidade;

        public Produto(int id, string nome, double preco, int quantidade)
        {
            this.id = id;
            this.nome = nome;
            this.preco = preco;
            this.quantidade = quantidade;
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

        public double Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public void AtualizarEstoque(int quantidade)
        {
            this.quantidade += quantidade;
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"ID: {id}, Nome: {nome}, Preço: {preco}, Quantidade: {quantidade}");
        }
    }

}
