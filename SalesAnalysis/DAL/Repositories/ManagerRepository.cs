using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DatabaseModel;

namespace DAL
{
    public class ManagerRepository : IRepository<Models.Manager>
    {
        private SalesEntities context = new SalesEntities();

        private  DatabaseModel.ManagerSet ToEntity(DAL.Models.Manager source)
        {
            return new DatabaseModel.ManagerSet() { Id = source.Id, FirstName = source.FirstName, SecondName = source.SecondName };
        }

        private Models.Manager ToObject(DatabaseModel.ManagerSet source)
        {
            return new Models.Manager() { Id = source.Id, FirstName = source.FirstName, SecondName = source.SecondName };
        }

        public void Add(Models.Manager item)
        {
            var e = this.ToEntity(item);
            context.ManagerSet.Add(e);
        }

        public void Remove(Models.Manager item)
        {
            var e = this.ToEntity(item);
            context.ManagerSet.Remove(e);
        }

        public void Update(Models.Manager item)
        {
            var e = this.ToEntity(item);
            context.Entry(e).State = EntityState.Modified;
        }

        public IEnumerable<Models.Manager> Items
        {
            get 
            { 
                foreach(var m in this.context.ManagerSet)
                {
                    yield return this.ToObject(m);
                }
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public int Count
        {
            get { return this.context.ManagerSet.Count(); }
        }
    }
}