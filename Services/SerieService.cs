using NTF.Series;
using NTF.Series.Repository;
using System;

namespace Ntf.Series.Services
{
    public class SerieService : IService<Serie>
	{
		private readonly IRepository<Serie> serieRepository = new SerieRepository();

		private bool endAppSerie = false;
		
		private string ObteropcaoSerie()
		{
			Console.WriteLine();
			Console.WriteLine(" *********** DIO - SÉRIES a seu dispor!!! *********** ");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();

			Console.WriteLine("     1- Listar séries");
			Console.WriteLine("     2- Inserir séries");
			Console.WriteLine("     3- Atualizar séries");
			Console.WriteLine("     4- Excluir séries");
			Console.WriteLine("     5- Visualizar séries");
			Console.WriteLine("     C- Limpar Tela");
			Console.WriteLine("     V- Voltar");
			Console.WriteLine();

			string opcaoSerie = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoSerie;
		}

		public void ExecutaMenu()
        {
			endAppSerie = false;

			string opcaoSerie = ObteropcaoSerie();

			while (!endAppSerie)
			{
				switch (opcaoSerie)
				{
					case "1":
						Listar();
						break;
					case "2":
						Inserir();
						break;
					case "3":
						Atualizar();
						break;
					case "4":
						Excluir();
						break;
					case "5":
						Visualizar();
						break;
					case "C":
						Console.Clear();
						break;
					case "V":
						endAppSerie = true;
						return;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoSerie = ObteropcaoSerie();
			}
		}

		private void Inserir()
		{
			var novaSerie = new Serie().Gerenciar(false, serieRepository.ProximoId());
			serieRepository.Insere(novaSerie);
		}

		private void Atualizar()
		{
			try
			{
				Console.Write("Digite o id da série: ");
				var id = int.Parse(Console.ReadLine());

				serieRepository.RetornaPorId(id);

				var atualizaSerie = new Serie().Gerenciar(true, id);
				serieRepository.Atualiza(atualizaSerie.Id, atualizaSerie);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private void Visualizar()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			try
			{
				var serie = serieRepository.RetornaPorId(indiceSerie);

				Console.WriteLine(serie);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private void Excluir()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			Console.Write("Tem certeza que deseja excluir?: (S/N) ");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			if (opcaoUsuario == "S")
			{
				try
				{
					serieRepository.Exclui(indiceSerie);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}
		
		private void Listar()
		{
			Console.WriteLine("Listar séries");

			var lista = serieRepository.Lista();
			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();

				Console.WriteLine("SÉRIE #ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

	}
}
