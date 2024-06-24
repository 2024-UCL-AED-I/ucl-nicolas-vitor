using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static ListaProdutos produtos = new ListaProdutos();
        static ListaClientes clientes = new ListaClientes();
        static string caminhoArquivoProdutos;
        static string caminhoArquivoClientes;

        static void Main(string[] args)
        {
            string diretorioAtual = AppDomain.CurrentDomain.BaseDirectory;
            caminhoArquivoProdutos = Path.Combine(diretorioAtual, "produtos.txt");
            caminhoArquivoClientes = Path.Combine(diretorioAtual, "clientes.txt");

            Console.WriteLine("BEM-VINDO");

            CarregarProdutos();
            CarregarClientes();

            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1. Adicionar Produto");
                Console.WriteLine("2. Adicionar Cliente");
                Console.WriteLine("3. Registrar Compra");
                Console.WriteLine("4. Exibir Relatórios");
                Console.WriteLine("5. Sair");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarProduto();
                        break;
                    case 2:
                        AdicionarCliente();
                        break;
                    case 3:
                        RegistrarCompra();
                        break;
                    case 4:
                        ExibirRelatorios();
                        break;
                    case 5:
                        SalvarProdutos();
                        SalvarClientes();
                        return;
                }
            }
        }

        static void AdicionarProduto()
        {
            Console.WriteLine("ID do Produto:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome do Produto:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço do Produto:");
            double preco = double.Parse(Console.ReadLine());
            Console.WriteLine("Quantidade:");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto = new Produto(id, nome, preco, quantidade);
            produtos.AdicionarUltimaPosicao(produto);
            SalvarProdutos();
        }

        static void AdicionarCliente()
        {
            Console.WriteLine("ID do Cliente: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome do Cliente: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();

            Cliente cliente = new Cliente(id, nome, email);
            clientes.AdicionarUltimaPosicao(cliente);
            SalvarClientes();
        }

        static void RegistrarCompra()
        {
            Console.WriteLine("ID do cliente:");
            int idCliente = int.Parse(Console.ReadLine());
            Cliente cliente = clientes.BuscarPorId(idCliente);

            Console.WriteLine("ID do produto:");
            int idProduto = int.Parse(Console.ReadLine());
            Produto produto = produtos.BuscarPorId(idProduto);

            if (cliente != null && produto != null)
            {
                Console.WriteLine("Quantidade desejada:");
                int quantidadeDesejada = int.Parse(Console.ReadLine());

                if (produto.Quantidade >= quantidadeDesejada)
                {
                    produto.AtualizarEstoque(-quantidadeDesejada);
                    Produto compra = new Produto(produto.Id, produto.Nome, produto.Preco, quantidadeDesejada);
                    cliente.AdicionarCompra(compra);
                    SalvarProdutos();
                    SalvarClientes();
                    Console.WriteLine("Compra registrada com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Estoque insuficiente. Apenas {produto.Quantidade} unidades disponíveis.");
                }
            }
            else
            {
                Console.WriteLine("Cliente ou produto não encontrado");
            }
        }

        static void ExibirRelatorios()
        {
            Console.WriteLine("\nProdutos: \n");
            produtos.ExibirProdutos();

            Console.WriteLine("\nClientes e suas Compras: \n");
            clientes.ImprimirLista();
        }

        static void SalvarProdutos()
        {
            using (StreamWriter writer = new StreamWriter(caminhoArquivoProdutos))
            {
                foreach (var produto in produtos)
                {
                    writer.WriteLine($"{produto.Id},{produto.Nome},{produto.Preco},{produto.Quantidade}");
                }
            }
        }

        static void SalvarClientes()
        {
            using (StreamWriter writer = new StreamWriter(caminhoArquivoClientes))
            {
                foreach (var cliente in clientes)
                {
                    writer.WriteLine($"{cliente.Id},{cliente.Nome},{cliente.Email}");
                    foreach (var compra in cliente.Compras)
                    {
                        writer.WriteLine($"{compra.Id},{compra.Nome},{compra.Preco},{compra.Quantidade}");
                    }
                }
            }
        }

        static void CarregarProdutos()
        {
            if (File.Exists(caminhoArquivoProdutos))
            {
                using (StreamReader reader = new StreamReader(caminhoArquivoProdutos))
                {
                    string linha;
                    while ((linha = reader.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(',');
                        int id = int.Parse(dados[0]);
                        string nome = dados[1];
                        double preco = double.Parse(dados[2]);
                        int quantidade = int.Parse(dados[3]);
                        Produto produto = new Produto(id, nome, preco, quantidade);
                        produtos.AdicionarUltimaPosicao(produto);
                    }
                }
            }
        }

        static void CarregarClientes()
        {
            if (File.Exists(caminhoArquivoClientes))
            {
                using (StreamReader reader = new StreamReader(caminhoArquivoClientes))
                {
                    string linha;
                    Cliente clienteAtual = null;
                    while ((linha = reader.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(',');
                        if (dados.Length == 3)
                        {
                            int id = int.Parse(dados[0]);
                            string nome = dados[1];
                            string email = dados[2];
                            clienteAtual = new Cliente(id, nome, email);
                            clientes.AdicionarUltimaPosicao(clienteAtual);
                        }
                        else if (dados.Length == 4 && clienteAtual != null)
                        {
                            int id = int.Parse(dados[0]);
                            string nome = dados[1];
                            double preco = double.Parse(dados[2]);
                            int quantidade = int.Parse(dados[3]);
                            Produto compra = new Produto(id, nome, preco, quantidade);
                            clienteAtual.AdicionarCompra(compra);
                        }
                    }
                }
            }
        }
    }
}

