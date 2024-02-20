using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ADONet.Models
{
    public class Cerveja
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estilo { get; set; }
        public string Coloracao { get; set; }
        public int TemperaturaDeConsumo { get; set; }
        public int IBU { get; set; }
        public decimal ABV { get; set; }
    }
}
