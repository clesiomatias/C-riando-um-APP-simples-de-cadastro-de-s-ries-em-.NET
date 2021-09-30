using System.Collections.Generic;
using DIO_series.Interfaces;
using DIO_series.Classes;

namespace DIO_Filmess.Classes
{
    public class FilmesRepositorio : IRepositorio<Filmes>
    {
        private List<Filmes> listaFilmes = new List<Filmes>();
        public void Atualiza(int id, Filmes entidade)
        {
            listaFilmes[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaFilmes[id].Excluir();
        }

        public void Insere(Filmes entidade)
        {
            listaFilmes.Add(entidade);
        }

        public List<Filmes> Lista()
        {
            return listaFilmes;
        }

        public int ProximoId()
        {
            return listaFilmes.Count;
        }

        public Filmes RetornaPorId(int id)
        {
            return listaFilmes[id];
        }
    }
}