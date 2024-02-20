using CRUD_ADONet.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_ADONet.View
{
    public static class Menu
    {
        public static void MenuCadastro()
        {
            Console.WriteLine("---- Menu ----");
            Console.WriteLine("1 - Cadastrar cerveja");
            Console.WriteLine("2 - Atualizar Cerveja");
            Console.WriteLine("3 - Pesquisar Cerveja");
            Console.WriteLine("4 - Deletar Cerveja");
            Console.WriteLine("--------------");
        }
        public static void MenuPesquisaCerveja()
        {
            Console.WriteLine("---- Menu ----");
            Console.WriteLine("1 - Buscar todas as Cervejas");
            Console.WriteLine("2 - Buscar cerveja por ID");
            Console.WriteLine("3 - Buscar cervejas por nome");
            Console.WriteLine("4 - Buscar cervejas por Estilo");
            //Console.WriteLine("3 - Pesquisar por Estilo");
            Console.WriteLine("--------------");
        }
   
        public static void NavegarMenuPrincipal()
        {
            string sairPrograma = "";

            while (sairPrograma != "s")
            {
                Menu.MenuCadastro();

                string receberDado;
                int result;

                Console.WriteLine("Digite um número de acordo ao menu:");
                receberDado = Console.ReadLine();
                while (!int.TryParse(receberDado, out result))
                {
                    Console.Clear();
                    Console.WriteLine("Digite um número de acordo ao menu.");
                    Menu.MenuCadastro();
                    receberDado = Console.ReadLine();
                }

                switch (result)
                {
                    case 1:
                        Console.Clear();
                        string cadastrar = "Cadastrar Cerveja";
                        Console.WriteLine(cadastrar);
                        for (int i = 0; i <= cadastrar.Length; i++)
                            Console.Write("-");

                        Cadastros.CadastrarCerveja();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Atualizar Cerveja;");
                        CrudCerveja.ConsultaCerveja();

                        string strIdCerveja;
                        int result2;
                        Console.WriteLine("Digite o ID da cerveja que será alterada:");
                        strIdCerveja = Console.ReadLine();
                        while (!int.TryParse(strIdCerveja, out result2))
                        {
                            Console.Clear();
                            Console.WriteLine("Digite o ID da cerveja que será alterada:");
                            Menu.MenuPesquisaCerveja();
                            strIdCerveja = Console.ReadLine();
                        }
                        Cadastros.AtualizarCerveja(result2);

                        break;
                    case 3:
                        Console.Clear();
                        NavegarMenuConsultaCerveja();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Atualizar Cerveja;");
                        CrudCerveja.ConsultaCerveja();

                        string strIdCvj;
                        int result3;
                        Console.WriteLine("Digite o ID da cerveja que será alterada:");
                        strIdCvj = Console.ReadLine();
                        while (!int.TryParse(strIdCvj, out result3))
                        {
                            Console.Clear();
                            Console.WriteLine("Digite o ID da cerveja que será alterada:");
                            Menu.MenuPesquisaCerveja();
                            strIdCvj = Console.ReadLine();
                        }
                        CrudCerveja.RemoverCerveja(result3);

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Item não encontrado.");
                        break;
                }

                Console.WriteLine("\n\nPara sair no programa digite S ou N para permanecer.");
                sairPrograma = Console.ReadLine().ToLower();

            }
        }
    
        public static void NavegarMenuConsultaCerveja()
        {
            string sairPrograma = "";

            while (sairPrograma != "s")
            {
                string menuResultado;
                int result2;
                Console.Clear();
                Menu.MenuPesquisaCerveja();

                Console.WriteLine("Digite um número de acordo ao menu:");
                menuResultado = Console.ReadLine();
                while (!int.TryParse(menuResultado, out result2))
                {
                    Console.Clear();
                    Console.WriteLine("Digite um número de acordo ao menu.");
                    Menu.MenuPesquisaCerveja();
                    menuResultado = Console.ReadLine();
                }

                switch (result2)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Buscar todas as Cervejas");
                        CrudCerveja.ConsultaCerveja();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Buscar cerveja por ID");
                        string IdSTR;
                        int IdInt;
                        Console.Clear();

                        Console.WriteLine("Digite o Id da cerveja:");
                        IdSTR = Console.ReadLine();
                        while (!int.TryParse(IdSTR, out IdInt))
                        {
                            Console.Clear();
                            Console.WriteLine("Digite o Id da cerveja:");
                            Menu.MenuPesquisaCerveja();
                            IdSTR = Console.ReadLine();
                        }
                        CrudCerveja.ConsultaCervejaPorId(IdInt);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Buscar cerveja por Nome");

                        Console.WriteLine("Digite o Nome da cerveja:");
                        string nomeCerveja = Console.ReadLine();

                        CrudCerveja.ConsultaCervejaPorNome(nomeCerveja);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Buscar cerveja por Estilo");

                        Console.WriteLine("Digite o Estilo da cerveja:");
                        string estiloCerveja = Console.ReadLine();

                        CrudCerveja.ConsultaCervejaPorEstilo(estiloCerveja);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Item não encontrado.");
                        break;
                }
                Console.WriteLine("\n\nPara sair do menu de consulta S ou N para Uma nova consulta.");
                sairPrograma = Console.ReadLine().ToLower();
            }
        }
    }
}
