using CRUD_ADONet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ADONet.Controller
{
    public class CrudCerveja
    {
        public bool CadastrarCerveja(Cerveja cvj)
        {
            string script = $"INSERT INTO tbCerveja (Nome, Estilo, Coloracao, TemperaturaDeConsumo, IBU, ABV) " +
                $"VALUES ('{cvj.Nome}' , '{cvj.Estilo}', '{cvj.Coloracao}', {cvj.TemperaturaDeConsumo}, {cvj.IBU}, {cvj.ABV})";

            try
            {
                int i = DataBase.ExecutaComando(script);

                if (i > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ConsultaCerveja()
        {
            var cervejas = DataBase.RetornaCerveja();

            Console.Clear();
            Console.WriteLine("|Id  |Nome             |Estilo            |Coloração          |Temperatura            |IBU            |ABV            |");
            foreach (var cvj in cervejas)
                Console.WriteLine($"|{cvj.Id}   |{cvj.Nome}             |{cvj.Estilo}            |{cvj.Coloracao}          |{cvj.TemperaturaDeConsumo}            |{cvj.IBU}            |{cvj.ABV}            |");
        }
        public static void ConsultaCervejaPorId(int Id)
        {
            var cervejas = DataBase.RetornaCerveja($"SELECT * FROM tbCerveja WHERE ID = {Id}");

            Console.Clear();
            if (cervejas.Count > 0)
            {
                Console.WriteLine("|Id  |Nome             |Estilo            |Coloração          |Temperatura            |IBU            |ABV            |");
                foreach (var cvj in cervejas)
                    Console.WriteLine($"|{cvj.Id}   |{cvj.Nome}             |{cvj.Estilo}            |{cvj.Coloracao}          |{cvj.TemperaturaDeConsumo}            |{cvj.IBU}            |{cvj.ABV}            |");
            }
            else
            {
                Console.WriteLine("Cerveja não encontrada.");
            }
        }
        public static void ConsultaCervejaPorNome(string NomeCerveja)
        {
            var cervejas = DataBase.RetornaCerveja($"SELECT * FROM tbCerveja WHERE Nome LIKE '%{NomeCerveja}%'");

            Console.Clear();
            if (cervejas.Count < 0)
            {
                Console.WriteLine("|Id  |Nome             |Estilo            |Coloração          |Temperatura            |IBU            |ABV            |");
                foreach (var cvj in cervejas)
                    Console.WriteLine($"|{cvj.Id}   |{cvj.Nome}             |{cvj.Estilo}            |{cvj.Coloracao}          |{cvj.TemperaturaDeConsumo}            |{cvj.IBU}            |{cvj.ABV}            |");
            }
            else
            {
                Console.WriteLine("Cerveja não encontrada.");
            }
        }
        public static void ConsultaCervejaPorEstilo(string EstiloCerveja)
        {
            var cervejas = DataBase.RetornaCerveja($"SELECT * FROM tbCerveja WHERE Estilo LIKE '%{EstiloCerveja}%'");

            Console.Clear();
            if (cervejas.Count < 0)
            {
                Console.WriteLine("|Id  |Nome             |Estilo            |Coloração          |Temperatura            |IBU            |ABV            |");
                foreach (var cvj in cervejas)
                    Console.WriteLine($"|{cvj.Id}   |{cvj.Nome}             |{cvj.Estilo}            |{cvj.Coloracao}          |{cvj.TemperaturaDeConsumo}            |{cvj.IBU}            |{cvj.ABV}            |");
            }
            else
            {
                Console.WriteLine("Cerveja não encontrada.");
            }
            
        }
        public bool AtualizarCerveja(Cerveja cvj)
        {
            string script = $@"UPDATE tbCerveja SET Nome = '{cvj.Nome}', Estilo = '{cvj.Estilo}', 
                        Coloracao = '{cvj.Coloracao}', TemperaturaDeConsumo = {cvj.TemperaturaDeConsumo}, 
                        IBU = {cvj.IBU}, ABV = {cvj.ABV} WHERE Id = {cvj.Id};";

            try
            {
                int i = DataBase.ExecutaComando(script);

                if (i > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void RemoverCerveja(int Id)
        {
            string returo;
            Console.WriteLine("A cerveja: ");
            CrudCerveja.ConsultaCervejaPorId(Id);
            Console.WriteLine("Será REMOVIDA PERMANENTEMENTE.");
            Console.WriteLine("Tem certeza em seguir com a remoção? \nDigite SIM para a atualização. Do contrário o");
            returo = Console.ReadLine().ToUpper();

            bool resposta = false;
            if (returo == "SIM")
            {
                CrudCerveja inserir = new CrudCerveja();
                string script = $@"DELETE FROM tbCerveja WHERE ID = {Id}";

                try
                {
                    int i = DataBase.ExecutaComando(script);

                    if (i > 0)
                        resposta = true;
                    else
                        resposta = false;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (resposta)
            {
                Console.Clear();
                Console.WriteLine($"Cerveja removida com sucesso.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Erro na removida da cerveja.");
            }            
        }
    }
}
