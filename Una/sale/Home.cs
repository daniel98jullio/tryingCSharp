using System;
namespace Una.sale
{
    public class Home
    {
        static void Main(string[] args)
        {
            new Home();
        }

        private Connection conn;
        private Venda venda;
        private Estoque estoque;
        private Operador operador;
        private Produto produto;

        public Home()
        {
            this.conn = new Connection();
            this.venda = new Venda(conn);
            this.estoque = new Estoque(conn);
            this.operador = new Operador(conn);
            this.produto = new Produto(conn);

            // this.login();
            this.menu();

            Console.ReadKey();
        }

        private void writeHeader()
        {
            Console.Clear();
            Console.WriteLine("======== Gestão de vendas ========");
        }

        private void login()
        {
            bool valido = true;
            do
            {
                this.writeHeader();
                Console.WriteLine("============ Login ===============");

                if (valido)
                    Console.WriteLine("|| Para acessar o sistema você deve informar...");
                else
                    Console.WriteLine("|| Usuário ou senha inválido! Tente novamente...");

                Console.Write("|| Nome: ");
                string nome = Console.ReadLine();
                Console.Write("|| Senha: ");
                string senha = Console.ReadLine();
                valido = this.operador.validaUsuario(nome, senha);
            } while (!valido);

        }

        private void menu()
        {
            this.writeHeader();
            Console.WriteLine("============ Menu ================");
            Console.WriteLine("|| 1) Cadastro de produto");
            Console.WriteLine("|| 2) Cadastro de venda");
            Console.WriteLine("|| 3) Entrada no estoque");
            Console.WriteLine("|| 9) Cadastro de operador");
            Console.WriteLine("|| 0) Sair");
            Console.Write("|| Selecione uma das opções ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    this.cadastroProduto();
                    break;
                case 2:
                    this.cadastroVenda();
                    break;
                case 9:
                    this.cadastroOperador();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private void cadastroProduto()
        {
            this.writeHeader();
            Console.WriteLine("====== Cadastro de produto =======");
            Console.WriteLine("|| Informe...");
            Console.Write("|| Código de barra: ");
            int codBar = int.Parse(Console.ReadLine());
            Console.Write("|| Nome: ");
            string nome = Console.ReadLine();
            Console.Write("|| Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("|| Valor: ");
            double valor = double.Parse(Console.ReadLine());
            this.produto.insert(codBar, nome, descricao, valor);
        }

        private void cadastroVenda()
        {
            this.writeHeader();
            Console.WriteLine("====== Cadastro de venda =======");
            Console.WriteLine("|| Informe...");
            Console.Write("|| Código de barra: ");
            int codBar = int.Parse(Console.ReadLine());
            Console.Write("|| Quantidade: ");
            double qt = double.Parse(Console.ReadLine());

            this.Validar_Quantidade_Estoque(codBar, qt);

            double vrDesc = 0;
            double vrTot = vrDesc = this.calcular_valor_do_item(codBar, qt);
            vrTot = this.calcular_valor_desconto_forma_pagamento(vrTot);
            Console.Write("|| O valor total à pagar é: " + vrTot);
            vrDesc -= vrTot;

            this.venda.insert(codBar, qt, vrDesc, vrTot);
        }

        private void cadastroOperador()
        {
            this.writeHeader();
            Console.WriteLine("====== Cadastro de operador =======");
            Console.WriteLine("|| Informe...");
            Console.Write("|| Nome: ");
            string nome = Console.ReadLine();
            Console.Write("|| Senha: ");
            string senha = Console.ReadLine();
            this.operador.insert(nome, senha);
        }

        public void emitir_cupom_fiscal() {
            
        }

        public double calcular_valor_desconto_forma_pagamento(double vrTot) {
            Console.WriteLine("|| Tipo de pagamento: ");
            Console.WriteLine("||   1) A vista - Dinheiro");
            Console.WriteLine("||   2) A vista - Débito");
            Console.WriteLine("||   3) Outros");
            Console.Write("|| Informe: ");
            int tpPag = int.Parse(Console.ReadLine());
            switch (tpPag)
            {
                case 1:
                    vrTot -= vrTot * 0.05;
                    break;
                case 2:
                    vrTot -= vrTot * 0.02;
                    break;
                default:
                    break;
            }
            return vrTot;
        }

        public double calcular_valor_do_item(int codBar, double qtDesej)
        {
            var produto = this.produto.busca(codBar);
            return produto.vrUnit * qtDesej;
        }

        public bool Validar_Quantidade_Estoque(int codBar, double qtDesej)
        {
            return false;
        }

        public void Atualizar_Estoque(int codBar, double qtProd)
        {

        }

        public void relatorioQtEstoque()
        {

        }
    }
}
