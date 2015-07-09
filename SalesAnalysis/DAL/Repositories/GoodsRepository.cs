using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DatabaseModel;

namespace DAL
{
    public class GoodsRepository : IRepository<Models.Goods>
    {
        private SalesEntities context = new SalesEntities();

        private DatabaseModel.GoodsSet ToEntity(DAL.Models.Goods source)
        {
            return new DatabaseModel.GoodsSet() { Id = source.Id, Name = source.Name };
        }

        private Models.Goods ToObject(DatabaseModel.GoodsSet source)
        {
            return new Models.Goods() { Id = source.Id, Name = source.Name };
        }

        public void Add(Models.Goods item)
        {
            var e = this.ToEntity(item);
            context.GoodsSet.Add(e);
        }

        public void Remove(Models.Goods item)
        {
            var e = this.ToEntity(item);
            context.GoodsSet.Remove(e);
        }

        public void Update(Models.Goods item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Goods> Items
        {
            get 
            { 
                foreach(var g in this.context.GoodsSet)
                {
                    yield return this.ToObject(g);
                }
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public int Count
        {
            get { return this.context.GoodsSet.Count(); }
        }
    }
}