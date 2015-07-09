using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DatabaseModel;

namespace DAL
{
    public class SalesRepository : IRepository<Models.Sales>
    {
        private SalesEntities context = new SalesEntities();

        private DatabaseModel.SalesSet ToEntity(Models.Sales source)
        {
            return new DatabaseModel.SalesSet()
            {
                Date = source.Date,
                ManagerId = source.Manager.Id,
                ClientId = source.Client.Id,
                GoodsId = source.Goodds.Id,
                Cost = source.Cost
            };
        }

        private Models.Sales ToObject(DatabaseModel.SalesSet source)
        {
            return new Models.Sales()
            {
                Date = source.Date,
                Manager = new Models.Manager() { Id = source.ManagerSet.Id, FirstName = source.ManagerSet.FirstName, SecondName = source.ManagerSet.SecondName },
                Client = new Models.Client() { Id = source.ClientSet.Id, Name = source.ClientSet.Name },
                Goodds = new Models.Goods() { Id = source.GoodsSet.Id, Name = source.GoodsSet.Name },
                Cost = source.Cost
            };
        }

        public void Add(Models.Sales item)
        {
            var e = this.ToEntity(item);
            context.SalesSet.Add(e);
        }

        public void Remove(Models.Sales item)
        {
            var e = this.ToEntity(item);
            context.SalesSet.Remove(e);
        }

        public void Update(Models.Sales item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Sales> Items
        {
            get 
            { 
                foreach(var s in this.context.SalesSet)
                {
                    yield return this.ToObject(s);
                }
            }
        }

        public void SaveChanges()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch(Exception e)
            {

            }
        }

        public int Count
        {
            get { return this.context.SalesSet.Count(); }
        }
    }
}