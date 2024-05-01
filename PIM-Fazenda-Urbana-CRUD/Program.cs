using PIM_Fazenda_Urbana_CRUD;
using System;

namespace PIMFazendaUrbana
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("===================== Cadastro de produtos =====================\n");

                Console.WriteLine("Selecione qual tela deseja acessar:");
                Console.WriteLine("[1] - Criar");
                Console.WriteLine("[2] - Listar");
                Console.WriteLine("[3] - Atualizar");
                Console.WriteLine("[4] - Deletar");

                Console.Write("\nOpção: ");

                int numberScreen = int.Parse(Console.ReadLine() ?? "0");
                if (numberScreen <= 0)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERRO]: Selecione uma opção válida\n");
                    Console.ResetColor();
                    
                    continue;
                }

                switch (numberScreen)
                {
                    case 1:
                        Create create = new Create();
                        create.CreateProductScreen();

                        break;
                    case 2:
                        Read read = new Read();
                        read.ReadProductScreen();

                        break;
                    case 3:
                        Update update = new Update();
                        update.UpdateProductScreen();

                        break;
                    case 4:
                        Delete delete = new Delete();
                        delete.DeleteProductScreen();

                        break;
                }
            }
        }
    }
}