using NTF.Filmes;
using NTF.Filmes.Repository;
using NTF.Series;
using System;

namespace Ntf.Series.Services
{
    public class FilmeService : IService<Filme>
	{
		private readonly IRepository<Filme> filmeRepository = new FilmeRepository();

		private bool endAppFilme = false;
		
		private string ObteropcaoFilme()
		{
			Console.WriteLine();
			Console.WriteLine(" *********** DIO - FILMES a seu dispor!!! *********** ");
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine();

			Console.WriteLine("     1- Listar filmes");
			Console.WriteLine("     2- Inserir filmes");
			Console.WriteLine("     3- Atualizar filmes");
			Console.WriteLine("     4- Excluir filmes");
			Console.WriteLine("     5- Visualizar filmes");
			Console.WriteLine("     C- Limpar Tela");
			Console.WriteLine("     V- Voltar");
			Console.WriteLine();

			string opcaoFilme = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoFilme;
		}

		public void ExecutaMenu()
        {
			endAppFilme = false;

			string opcaoFilme = ObteropcaoFilme();

			while (!endAppFilme)
			{
				switch (opcaoFilme)
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
						endAppFilme = true;
						return;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoFilme = ObteropcaoFilme();
			}
		}

		private void Inserir()
		{
			var novoFilme = new Filme().Gerenciar(false, filmeRepository.ProximoId());
			filmeRepository.Insere(novoFilme);
		}

		private void Atualizar()
		{
			try
			{
				Console.Write("Digite o id do filme: ");
				var id = int.Parse(Console.ReadLine());

				filmeRepository.RetornaPorId(id);

				var atualizaFilme = new Filme().Gerenciar(true, id);
				filmeRepository.Atualiza(atualizaFilme.Id, atualizaFilme);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private void Visualizar()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());
			try
			{
				var filme = filmeRepository.RetornaPorId(indiceFilme);

				Console.WriteLine(filme);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private void Excluir()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			Console.Write("Tem certeza que deseja excluir?: (S/N) ");
			string opcaoUsuario1 = Console.ReadLine().ToUpper();
			Console.WriteLine();
			if (opcaoUsuario1 == "S")
			{
				try
				{
					filmeRepository.Exclui(indiceFilme);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}

		private void Listar()
		{
			Console.WriteLine("Listar filmes");

			var listaFilme = filmeRepository.Lista();
			if (listaFilme.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in listaFilme)
			{
				var excluido = filme.retornaExcluido();

				Console.WriteLine("FILME #ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

	}
}
