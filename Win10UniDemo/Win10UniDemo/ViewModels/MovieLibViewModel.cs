using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win10UniDemo.Models;

namespace Win10UniDemo.ViewModels
{
    public class MovieLibViewModel : IList<Models.IMovieItem>
    {
        private List<Models.IMovieItem> movies = new List<IMovieItem>();
        public IEnumerable<FilmProductionStudio> ProductionStudios { get { return movies.Select(m => m.ProductionStudio).Distinct(); } }

        public int Count { get { return movies.Count; } }

        public bool IsReadOnly { get { return false; } }

        public IMovieItem this[int index]
        {
            get
            {
                return movies[index];
            }

            set
            {
                movies[index] = value;
            }
        }

        public void Add(IMovieItem item)
        {
            movies.Add(item);
        }

        public void AddRange(IEnumerable<Models.IMovieItem> items)
        {
            movies.AddRange(items);
        }

        public void Clear()
        {
            movies.Clear();
        }

        public bool Contains(IMovieItem item)
        {
            return movies.Contains(item);
        }

        public void CopyTo(IMovieItem[] array, int arrayIndex)
        {
            movies.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IMovieItem> GetEnumerator()
        {
            return movies.GetEnumerator();
        }

        public bool Remove(IMovieItem item)
        {
            return movies.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<Models.FilmProductionStudio> GetFilmStudiosCollection()
        {
            return movies.Select(m => m.ProductionStudio).Distinct();
        }

        public int IndexOf(IMovieItem item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IMovieItem item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
