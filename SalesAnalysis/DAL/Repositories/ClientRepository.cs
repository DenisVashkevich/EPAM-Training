using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DatabaseModel;

namespace DAL
{
    public class ClientRepository : IRepository<DAL.Models.Client>
    {
        private SalesEntities context = new SalesEntities();

        private DatabaseModel.ClientSet ToEntity(Models.Client source)
        {
            return new DatabaseModel.ClientSet() { Id = source.Id, Name = source.Name };
        }

        private Models.Client ToObject(DatabaseModel.ClientSet source)
        {
            return new Models.Client() { Id = source.Id, Name = source.Name };
        }

        public void Add(Models.Client item)
        {
            var e = this.ToEntity(item);
            context.ClientSet.Add(e);
        }

        public void Remove(Models.Client item)
        {
            var itm = context.ClientSet.FirstOrDefault(x => x.Id == item.Id);
            if (itm != null)
            {
                context.ClientSet.Remove(itm);
            }
        }

        public void Update(Models.Client item)
        {
            var itm = context.ClientSet.FirstOrDefault(x => x.Id == item.Id);
            if (itm != null)
            {
                context.Entry(itm).State = EntityState.Modified;
            }
        }

        public IEnumerable<Models.Client> Items
        {
            get 
            { 
                foreach(var c in this.context.ClientSet)
                {
                    yield return this.ToObject(c);
                }
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public int Count
        {
            get { return this.context.ClientSet.Count(); }
        }
    }
}