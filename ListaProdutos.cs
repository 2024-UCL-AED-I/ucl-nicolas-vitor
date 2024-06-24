using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ListaProdutos : System.Collections.Generic.List<Produto>
    {
        public void AdicionarUltimaPosicao(Produto produto)
        {
            this.Add(produto);
        }

        public Produto BuscarPorId(int id)
        {
            return this.Find(p => p.Id == id);
        }

        public void ExibirProdutos()
        {
            foreach (var produto in this)
            {
                produto.ExibirDetalhes();
            }
        }
    }
}
