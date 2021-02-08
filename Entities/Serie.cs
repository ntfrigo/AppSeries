using Ntf.Series.Helper;
using System;
using System.Text;

namespace NTF.Series
{
    public class Serie : EntityBase
    {
		public Serie()
        {
        }

		public Serie Gerenciar(bool atualizar, int id)
        {
            if (!atualizar)
            {
				Console.WriteLine("Inserir nova série");
			}
						
			foreach (int i in Enum.GetValues(typeof(Generos)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Generos), i));
			}
			Console.Write("Digite o gênero entre as opções acima".ToFormatStr(45));
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série".ToFormatStr(45));
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série".ToFormatStr(45));
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série".ToFormatStr(45));
			string entradaDescricao = Console.ReadLine();

			return new Serie(id: id,
										genero: (Generos)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);
		}

		private Generos Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

		private Serie(int id, Generos genero, string titulo, string descricao, int ano)
		{
			this.Id = id;
			this.Genero = genero;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;
		}              

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() 
        {
            this.Excluido = true;
        }

        public override string ToString()
		{
			var retorno = new StringBuilder();
			retorno.Append("Gênero".ToFormatStrLine(this.Genero));
			retorno.Append("Titulo".ToFormatStrLine(this.Titulo));
			retorno.Append("Descrição".ToFormatStrLine(this.Descricao));
			retorno.Append("Ano de Início".ToFormatStrLine(this.Ano));
			retorno.Append("Excluido".ToFormatStrLine(this.Excluido));
			return retorno.ToString();
		}
    }
}