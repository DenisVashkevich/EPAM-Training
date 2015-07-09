//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity;

//namespace DAL
//{
//    public abstract class AbstractRepository<C, T> : IRepository<T> where T : class where C : DbContext, new ()
//    {
//        //private SalesDataModel.DataModelContainer context = new SalesDataModel.DataModelContainer();
//        private C _context = new C();
//        public C Context 
//        {
//            get { return _context; }
//            set { _context = value; }
//        }

//        protected virtual ToEntity(T source);
//        //private SalesDataModel.Client ToEntity(DAL.Models.Client source)
//        //{
//        //    return new SalesDataModel.Client() { Id = source.Id, Name = source.Name };
//        //}

//        protected virtual abstract T ToObject(object source);
//        //private DAL.Models.Client ToObject(SalesDataModel.Client source)
//        //{
//        //    return new DAL.Models.Client() { Id = source.Id, Name = source.Name };
//        //}

//        public virtual void Add(T item)
//        {
//            var e = this.ToEntity(item);
//            _context.Set<T>().Add(e);
//            //context.ClientSet.Add(e);
//        }

//        public void Remove(Models.Client item)
//        {
//            var e = this.ToEntity(item);
//            context.ClientSet.Remove(e);
//        }

//        public void Update(Models.Client item)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Models.Client> Items
//        {
//            get
//            {
//                foreach (var c in this.context.ClientSet)
//                {
//                    yield return this.ToObject(c);
//                }
//            }
//        }

//        public void SaveChanges()
//        {
//            this.context.SaveChanges();
//        }

//        public int Count
//        {
//            get { return this.context.ClientSet.Count(); }
//        }
//    }
//}
