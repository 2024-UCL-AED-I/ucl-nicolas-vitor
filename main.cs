using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Produto> produtos = new List<Produto>();
    static List<Cliente> clientes = new List<Cliente>();

    static void Main(string[] args)
    {
        // Menu
        while (true)
        {
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
                    return;
            }
        }
    }

    static void AdicionarProduto()
    {
        Console.WriteLine("ID:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("Preço:");
        double preco = double.Parse(Console.ReadLine());
        Console.WriteLine("Quantidade:");
        int quantidade = int.Parse(Console.ReadLine());

        Produto produto = new Produto(id, nome, preco, quantidade);
        produtos.Add(produto);
        SalvarProdutos();
    }

    static void AdicionarCliente()
    {
        Console.WriteLine("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Nome: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Email:");
        string email = Console.ReadLine();

        Cliente cliente = new Cliente(id, nome, email);
        clientes.Add(cliente);
        SalvarClientes();
    }

    static void RegistrarCompra()
    {
        Console.WriteLine("ID do cliente:");
        int idCliente = int.Parse(Console.ReadLine());
        Cliente cliente = clientes.Find(c => c.Id == idCliente);

        Console.WriteLine("ID do produto:");
        int idProduto = int.Parse(Console.ReadLine());
        Produto produto = produtos.Find(p => p.Id == idProduto);

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
        Console.WriteLine("Produtos:");
        foreach (var produto in produtos)
        {
            produto.ExibirDetalhes();
        }

        Console.WriteLine("Clientes e suas Compras:");
        foreach (var cliente in clientes)
        {
            cliente.ExibirCompras();
        }
    }

    static void SalvarProdutos()
    {
        using (StreamWriter writer = new StreamWriter("produtos.txt"))
        {
            foreach (var produto in produtos)
            {
                writer.WriteLine($"{produto.Id},{produto.Nome},{produto.Preco},{produto.Quantidade}");
            }
        }
    }

    static void SalvarClientes()
    {
        using (StreamWriter writer = new StreamWriter("clientes.txt"))
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
}

class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }

    public Produto(int id, string nome, double preco, int quantidade)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"ID: {Id}, Nome: {Nome}, Preço: {Preco}, Quantidade: {Quantidade}");
    }

    public void AtualizarEstoque(int quantidade)
    {
        Quantidade += quantidade;
    }
}

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public List<Produto> Compras { get; set; }

    public Cliente(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Compras = new List<Produto>();
    }

    public void AdicionarCompra(Produto produto)
    {
        Compras.Add(produto);
    }

    public void ExibirCompras()
    {
        Console.WriteLine($"Compras do Cliente {Nome}:");
        foreach (var produto in Compras)
        {
            produto.ExibirDetalhes();
        }
    }
}
