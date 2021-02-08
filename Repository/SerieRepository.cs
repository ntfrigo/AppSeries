using System.Collections.Generic;

namespace NTF.Series.Repository
{
    public class SerieRepository : IRepository<Serie>
    {
		private List<Serie> listaSerie = new List<Serie>();
		public void Atualiza(int id, Serie objeto)
		{			
			listaSerie[id] = objeto;
		}

		public void Exclui(int id)
		{
			RetornaPorId(id);
			listaSerie[id].Excluir();
		}

		public void Insere(Serie objeto)
		{
			listaSerie.Add(objeto);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count+1;
		}

		public Serie RetornaPorId(int id)
		{
            try
            {
				return listaSerie[id];
			}
            catch (System.Exception)
            {
                throw new System.Exception($"Serie de código: {id} não encontrada!");
            }		

		}

	}
}
