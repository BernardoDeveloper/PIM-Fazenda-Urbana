using PIM_Fazenda_Urbana_CRUD.database;
using PIM_Fazenda_Urbana_CRUD.handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_Fazenda_Urbana_CRUD
{
    internal class Delete
    {
        public Delete() { }

        public void DeleteProductScreen()
        {
            Console.Clear();

            Console.WriteLine("===================== Deletar um produto =====================\n");

            Console.WriteLine("Digite os dados do produto para deletar");

            Console.Write("Nome: ");
            string productName = Console.ReadLine() ?? "nome não definido";

            var connection = new Connection();
            connection.ExecutarComandoSql($"DELETE FROM product WHERE name = '{productName}'");

            Console.WriteLine("\nProduto removido com sucesso :)");

            Console.WriteLine("\n[0] - voltar");
            Console.Write("\nOpção: ");

            int numberScreen = int.Parse(Console.ReadLine() ?? "0");
            if (numberScreen != 0)
            {
                var errorMessage = new ErrorHandler();
                errorMessage.ErrorHandlerMessage("Selecione uma opção válida");
            }
            else
            {
                Home home = new Home();
                home.HomeScreen();
            }
        }
    }
}
