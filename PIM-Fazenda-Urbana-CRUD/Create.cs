using Microsoft.Data.SqlClient;
using PIM_Fazenda_Urbana_CRUD.database;
using PIM_Fazenda_Urbana_CRUD.handler;
using PIMFazendaUrbana;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_Fazenda_Urbana_CRUD
{
    internal class Create
    {
        public Create() { }

        public void CreateProductScreen()
        {
            Console.Clear();

            Console.WriteLine("===================== Criar um produto =====================\n");

            Console.WriteLine("Digite os dados do produto para inserir");

            // Valores digitados pelo usuário
            Console.Write("Nome: ");
            string productName = Console.ReadLine() ?? "nome não definido";

            Console.Write("Descrição: ");
            string description = Console.ReadLine() ?? "descrição não definido";

            Console.Write("Preço: ");
            float priceProduct = float.Parse(Console.ReadLine() ?? "0.0");

            // Database initialization
            var connection = new Connection();

            connection.ExecutarComandoSql($"INSERT INTO product (name, description, price) VALUES ('{productName}', '{description}', {priceProduct})");

            // Get the result from select and show then
            Console.WriteLine("\nProduto adicionado: ");
            connection.ListProduct($"name = '{productName}'");

            Console.WriteLine("\n[0] - voltar");
            Console.Write("\nOpção: ");

            int numberScreen = int.Parse(Console.ReadLine() ?? "0");
            if (numberScreen < 0 || numberScreen > 4)
            {
                var errorMessage = new ErrorHandler();
                errorMessage.ErrorHandlerMessage("Select a valid option");
            }
            else
            {
                Home home = new Home();
                home.HomeScreen();
            }
        }
    }
}
