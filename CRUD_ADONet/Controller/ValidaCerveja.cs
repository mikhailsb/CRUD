using CRUD_ADONet.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ADONet.Controller
{
    public class ValidaCerveja
    {
        public static string ValidarCadCerveja(Cerveja cvj)
        {
            string retornoValidacao = "";
            if (cvj.Nome == "")
                retornoValidacao += "O campo Nome é obrigatório.\n";
            else if(ValidaNomeCerveja(cvj.Nome))
                retornoValidacao += "Cerveja já cadastrada.\n";

            if (cvj.Estilo == "")
                retornoValidacao += "O campo Estilo é obrigatório.\n";

            if (cvj.Coloracao == "")
                retornoValidacao += "O campo Coloração é obrigatório.\n";

            if (cvj.TemperaturaDeConsumo == 0)
                retornoValidacao += "A temperatura de consumo em 0 Cº é impropria pra consumo.\n";

            if (cvj.IBU == 0)
                retornoValidacao += "O IBU 0 é inválido.\n";

            if (cvj.ABV == 0)
                retornoValidacao += "O teor alcoólico em 0 não é valido neste programa.\n";

            return retornoValidacao;
        }

        public static bool ValidaNomeCerveja(string nomeCerveja)
        {
            string query = $"SELECT * FROM tbCerveja WHERE Nome = '{nomeCerveja}'";

            var dr = DataBase.RetornaCerveja(query);

            if (dr.Count > 0) return true;
            else return false;
        }
    }
}
