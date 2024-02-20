using CRUD_ADONet.Controller;
using CRUD_ADONet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ADONet.View
{
    public static class Cadastros
    {
        public static void CadastrarCerveja()
        {
            Cerveja cvj = new Cerveja();

            Console.WriteLine();
            Console.WriteLine("Digite o nome da Cerveja:");
            cvj.Nome = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite o estilo da Cerveja:");
            cvj.Estilo = Console.ReadLine();

            Console.WriteLine("Digite a cor da Cerveja:");
            cvj.Coloracao = Console.ReadLine();

            string resultado = null;
            int result;

            Console.WriteLine("Digite a temperatura de consumo da Cerveja:");
            resultado = Console.ReadLine();
            while (!int.TryParse(resultado, out result))
            {
                Console.WriteLine("Por gentileza digite a temperatura corretemente.");
                resultado = Console.ReadLine();
            }
            cvj.TemperaturaDeConsumo = result;
            resultado = null;

            Console.WriteLine("Digite o IBU da Cerveja:");
            resultado = Console.ReadLine();
            while (!int.TryParse(resultado, out result))
            {
                Console.WriteLine("Por gentileza digite a IBU corretamente.");
                resultado = Console.ReadLine();
            }
            cvj.IBU = result;
            resultado = null;

            Console.WriteLine("Digite o teor alcoólico da Cerveja:");
            resultado = Console.ReadLine();
            while (!int.TryParse(resultado, out result))
            {
                Console.WriteLine("Por gentileza digite o teor alccólico corretamente.");
                resultado = Console.ReadLine();
            }
            cvj.ABV = result;

            string retornoValidacao = ValidaCerveja.ValidarCadCerveja(cvj);

            if (retornoValidacao != "")
            {
                Console.Clear();
                Console.WriteLine("Dados informados incorretamente.");
                Console.WriteLine("Segue os dados digitados incorretamente.");
                Console.WriteLine(retornoValidacao);
            }
            else
            {
                CrudCerveja inserir = new CrudCerveja();
                var resposta = inserir.CadastrarCerveja(cvj);

                if (resposta)
                {
                    Console.Clear();
                    Console.WriteLine("Cadastro realizado com sucesso.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Erro ao Cadastrar cerveja.");
                }
            }
        }

        public static void AtualizarCerveja(int IDCerveja)
        {
            Cerveja cvj = new Cerveja();

            Console.WriteLine();
            Console.WriteLine("Digite o nome da Cerveja:");
            cvj.Nome = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite o estilo da Cerveja:");
            cvj.Estilo = Console.ReadLine();

            Console.WriteLine("Digite a cor da Cerveja:");
            cvj.Coloracao = Console.ReadLine();

            string resultado = null;
            int result;

            Console.WriteLine("Digite a temperatura de consumo da Cerveja:");
            resultado = Console.ReadLine();
            while (!int.TryParse(resultado, out result))
            {
                Console.WriteLine("Por gentileza digite a temperatura corretemente.");
                resultado = Console.ReadLine();
            }
            cvj.TemperaturaDeConsumo = result;
            resultado = null;

            Console.WriteLine("Digite o IBU da Cerveja:");
            resultado = Console.ReadLine();
            while (!int.TryParse(resultado, out result))
            {
                Console.WriteLine("Por gentileza digite a IBU corretamente.");
                resultado = Console.ReadLine();
            }
            cvj.IBU = result;
            resultado = null;

            Console.WriteLine("Digite o teor alcoólico da Cerveja:");
            resultado = Console.ReadLine();
            while (!int.TryParse(resultado, out result))
            {
                Console.WriteLine("Por gentileza digite o teor alccólico corretamente.");
                resultado = Console.ReadLine();
            }
            cvj.ABV = result;
            cvj.Id = IDCerveja;

            string retornoValidacao = ValidaCerveja.ValidarCadCerveja(cvj);

            if (retornoValidacao != "")
            {
                Console.Clear();
                Console.WriteLine("Dados informados incorretamente.");
                Console.WriteLine("Segue os dados digitados incorretamente.");
                Console.WriteLine(retornoValidacao);
            }
            else
            {
                string returo;
                Console.WriteLine("A cerveja: ");
                CrudCerveja.ConsultaCervejaPorId(cvj.Id);
                Console.WriteLine("Será substituído pelos dados digitados.");
                Console.WriteLine("Tem certeza da alteração? \nDigite SIM para a atualização. Do contrário o");
                returo = Console.ReadLine().ToUpper();

                bool resposta = false;
                if (returo == "SIM")
                {
                    CrudCerveja inserir = new CrudCerveja();
                    resposta = inserir.AtualizarCerveja(cvj);
                }
                
                if (resposta)
                {
                    Console.Clear();
                    Console.WriteLine($"Cerveja {cvj.Nome} atualizada com sucesso.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Erro ao atualizadar cerveja {cvj.Nome}.");
                }
            }
        }
    }
}
