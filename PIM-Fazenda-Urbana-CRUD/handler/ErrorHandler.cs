using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_Fazenda_Urbana_CRUD.handler
{
    class ErrorHandler
    {
        public ErrorHandler() { }

        public void ErrorHandlerMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERRO]: {errorMessage}\n");
            Console.ResetColor();
        }
    }
}
