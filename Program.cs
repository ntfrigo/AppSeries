using Ntf.Series.Services;
using NTF.Filmes;
using NTF.Series;
using System;

namespace Ntf.Series
{
    class Program
    {
        static IService<Filme> filmeService = new FilmeService();
        static IService<Serie> serieService = new SerieService();

        static void Main(string[] args)
        {
            bool showMenu = false;
            string opcao1 = TipoOperacao();

            while (!showMenu)
            {
                switch (opcao1)
                {
                    case "1":
                        serieService.ExecutaMenu();
                        break;
                    case "2":
                        filmeService.ExecutaMenu();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        showMenu = true;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if(!showMenu) opcao1 = TipoOperacao();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static string TipoOperacao()
        {
            Console.WriteLine();
            Console.WriteLine(" *********** DIO Séries e Filmes a seu dispor!!! *********** ");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("     1- Séries");
            Console.WriteLine("     2- Filmes");
            Console.WriteLine("     C- Limpar Tela");
            Console.WriteLine("     X- Sair");
            Console.WriteLine();

            string opcao1 = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao1;
        }

    }
}
