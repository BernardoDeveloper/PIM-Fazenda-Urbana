using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_Fazenda_Urbana_CRUD.database
{
    internal class SearchProductByName
    {
        public void SearchProduct(string productName) {
            var connection = new Connection();
            connection.ExecutarComandoSql($"SELECT * FROM product WHERE name = '{productName}'");
        }        
    }
}
