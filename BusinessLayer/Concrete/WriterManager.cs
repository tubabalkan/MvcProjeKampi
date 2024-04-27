using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public writer GetById(int id)
        {
            return _writerDal.Get(x => x.writerId == id);
        }

        public List<writer> GetList()
        {
            return _writerDal.List();
        }

        public void WriterAdd(writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
