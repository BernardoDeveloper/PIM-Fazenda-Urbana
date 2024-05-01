using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM_Fazenda_Urbana_CRUD.Models
{
    internal class Products
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}
