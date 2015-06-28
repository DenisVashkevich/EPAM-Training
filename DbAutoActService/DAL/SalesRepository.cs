﻿using System;
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
            return new SalesDataModel.Sales() { 
                Date = source.Date, 
                Manager = context.ManagerSet.FirstOrDefault(x=>x.Id == source.Manager.Id), 
                Client = context.ClientSet.FirstOrDefault(x=>x.Id == source.Client.Id), 
                Goods = context.GoodsSet.FirstOrDefault(x=>x.Id == source.Goodds.Id),
                Cost 
            };
        }

        private DAL.Models.Manager ToObject(SalesDataModel.Manager source)
        {
            return new DAL.Models.Manager() { Id = source.Id, FirstName = source.FirstName, SecondName = source.SecondName };
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
            throw new NotImplementedException();
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