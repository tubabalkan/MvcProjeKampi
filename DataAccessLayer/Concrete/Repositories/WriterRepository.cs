using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class WriterRepository : IWriterDal
    {
        Context c = new Context();
        DbSet<writer> _object;
        public void Delete(writer p)
        {
            throw new NotImplementedException();
        }

        public writer Get(Expression<Func<writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(writer p)
        {
            throw new NotImplementedException();
        }

        public List<writer> List()
        {
            throw new NotImplementedException();
        }

        public List<writer> List(Expression<Func<writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(writer p)
        {
            throw new NotImplementedException();
        }
    }
}
