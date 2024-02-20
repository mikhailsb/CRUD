using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ADONet.Models
{
    public class Conexao
    {
        static string connectionString { get; } = @"Server=.\sqlexpress;Database=HarmonizaComQ;Trusted_Connection=True;";

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}
