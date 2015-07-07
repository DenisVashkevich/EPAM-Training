using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class SalesRepository : IRepository<DAL.Models.Sales>
    {
        private SalesDataModel.DataModelContainer context = new SalesDataModel.DataModelContainer();

        private SalesDataModel.Sales ToEntity(DAL.Models.Sales source)
        {
            return new SalesDataModel.Sales()
            {
                Date = source.Date,
                ManagerId = source.Manager.Id,
                ClientId = source.Client.Id,
                GoodsId = source.Goodds.Id,
                Cost = source.Cost
            };
        }

        private DAL.Models.Sales ToObject(SalesDataModel.Sales source)
        {
            return new DAL.Models.Sales()
            {
                Date = source.Date,
                Manager = new DAL.Models.Manager() { Id = source.Manager.Id, FirstName = source.Manager.FirstName, SecondName = source.Manager.SecondName },
                Client = new DAL.Models.Client() { Id = source.Client.Id, Name = source.Client.Name },
                Goodds = new DAL.Models.Goods() { Id = source.Goods.Id, Name = source.Goods.Name },
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