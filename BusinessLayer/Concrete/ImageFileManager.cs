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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _ImageFileDal;

        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            _ImageFileDal = ımageFileDal;
        }

        public List<ImageFile> GetList()
        {
           return _ImageFileDal.List();

        }
    }
}
