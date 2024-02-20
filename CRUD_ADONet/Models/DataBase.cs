using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ADONet.Models
{
    public class DataBase
    {
        public static int ExecutaComando(string script)
        {
            SqlConnection cv = new SqlConnection(Conexao.GetConnectionString());

            SqlCommand cmd = new SqlCommand(script, cv);
            cmd.CommandType = CommandType.Text;

            cv.Open();
            try
            {
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                cv.Close();
            }
        }

        public static List<Cerveja> RetornaCerveja(string query = "SELECT * FROM tbCerveja")
        {
            List<Cerveja> cervejas = new List<Cerveja>();
            SqlConnection cn = new SqlConnection(Conexao.GetConnectionString());

            SqlCommand cvm = new SqlCommand(query, cn);
            cvm.CommandType = CommandType.Text;
            SqlDataReader rdr;
            cn.Open();
            try
            {
                rdr = cvm.ExecuteReader();
                if (rdr.HasRows)
                {
                    while(rdr.Read())
                    {
                        Cerveja crvj = new Cerveja();
                        crvj.Id = rdr.GetInt32(0);
                        crvj.Nome = rdr.GetString(1);
                        crvj.Estilo = rdr.GetString(2);
                        crvj.Coloracao = rdr.GetString(3);
                        crvj.TemperaturaDeConsumo = rdr.GetInt32(4);
                        crvj.IBU = rdr.GetInt32(5);
                        crvj.ABV = rdr.GetDecimal(6);

                        cervejas.Add(crvj);
                    }
                }
                return cervejas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }

    }
}
