using PIM_Fazenda_Urbana_CRUD.database;
using PIM_Fazenda_Urbana_CRUD.handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_Fazenda_Urbana_CRUD
{
    internal class Update
    {
        // public string Id { get; set; }

        public Update() { }

        public void UpdateProductScreen()
        {
            Console.Clear();

            Console.WriteLine("===================== Atualizar um produto =====================\n");
            
            Console.WriteLine("Digite os dados do produto para atualizar");

            // Valores digitados pelo usuário
            Console.Write("ID: ");
            string productId = Console.ReadLine() ?? "0";

            Console.Write("Nome: ");
            string productName = Console.ReadLine() ?? "nome não definido";

            Console.Write("Descrição: ");
            string description = Console.ReadLine() ?? "descrição não definido";

            Console.Write("Preço: ");
            float priceProduct = float.Parse(Console.ReadLine() ?? "0.0");

            var connection = new Connection();
            connection.ExecutarComandoSql($"UPDATE product SET name = '{productName}', description = '{description}', price = {priceProduct} WHERE id = {productId}");

            Console.WriteLine("\nProduto atualizado");
            connection.ListProduct($"id = {productId}");

            Console.WriteLine("\n[0] - voltar");
            Console.Write("\nOpção: ");

            int numberScreen = int.Parse(Console.ReadLine() ?? "0");
            if (numberScreen != 0)
            {
                var errorMessage = new ErrorHandler();
                errorMessage.ErrorHandlerMessage("Selcione uma opção válida");
            }
            else
            {
                Home home = new Home();
                home.HomeScreen();
            }
 
        }
    }
}
