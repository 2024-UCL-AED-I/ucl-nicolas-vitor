class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }

    public Produto(int id, string nome, double preco)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Quantidade = Quantidade;
    }

        public void ExibitDetalhes()
        {
            Console.WriteLine($"ID: {Id},Nome:{Nome},Preço:{Preco},Quantidade:{Quantidade}");
        }

        public void AtualizarEstoque(int quantidade)
        {
            Quantidade += quantidade;
        }
    }
}

    class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Produto> Compras { get; set; }

        public Cliente(int id,string nome, string email)
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

    class Program
    {
        static List<Produto> produtos = new List<Produto>();
        static List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args)
        {
            //Menu
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
            double Preco = double.Parse(Console.ReadLine());
            Console.WriteLine("Quantidade:");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto = new Produto(id, nome, preco, quantidade);
            produto.Add(produto);
            SalvarProdutos();
        }
    }
}
