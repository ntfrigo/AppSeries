using NTF.Series;
using System.Collections.Generic;

namespace NTF.Filmes.Repository
{
    public class FilmeRepository : IRepository<Filme>
    {
		private List<Filme> listaFilme = new List<Filme>();
		public void Atualiza(int id, Filme objeto)
		{			
			listaFilme[id] = objeto;
		}

		public void Exclui(int id)
		{
			RetornaPorId(id);
			listaFilme[id].Excluir();
		}

		public void Insere(Filme objeto)
		{
			listaFilme.Add(objeto);
		}

		public List<Filme> Lista()
		{
			return listaFilme;
		}

		public int ProximoId()
		{
			return listaFilme.Count+1;
		}

		public Filme RetornaPorId(int id)
		{
            try
            {
				return listaFilme[id];
			}
            catch (System.Exception)
            {
                throw new System.Exception($"Filme de código: {id} não encontrado!");
            }		

		}

	}
}
