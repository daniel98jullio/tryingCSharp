using System;
namespace Una.sale
{
    public class Home
    {
        static void Main(string[] args)
        {
            Connection conn = new Connection();

            Venda venda = new Venda(conn);
            Estoque estoque = new Estoque(conn);
            Operador operador = new Operador(conn);
            Produto produto = new Produto(conn);

            var a = estoque.busca();

            Console.ReadKey();
        }

        public void emitir_cupom_fiscal() {
            
        }

        public void calcular_valor_desconto_forma_pagamento() {
            
        }
    }
}
