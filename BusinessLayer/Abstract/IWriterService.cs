using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<writer> GetList();
        void WriterAdd(writer writer);
        void WriterDelete(writer writer);
        void WriterUpdate(writer writer);
        writer GetById(int id);
    }
}
