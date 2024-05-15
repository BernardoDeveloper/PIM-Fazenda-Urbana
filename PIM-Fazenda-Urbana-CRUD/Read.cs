using PIM_Fazenda_Urbana_CRUD.database;
using PIM_Fazenda_Urbana_CRUD.handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_Fazenda_Urbana_CRUD
{
    internal class Read
    {
        public Read() { }

        public void ReadProductScreen()
        {
            Console.Clear();

            Console.WriteLine("===================== Listagem dos produtos =====================\n");

            var connection = new Connection();
            connection.ListProduct(null);

            Console.WriteLine("\n[0] - voltar");
            Console.Write("\nOpção: ");

            int numbreScreen = int.Parse(Console.ReadLine() ?? "0");
            if (numbreScreen != 0)
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
