using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillManager : ISkillService
    {
        ISkillDal _ıskillDal;

        public SkillManager(ISkillDal ıskillDal)
        {
            _ıskillDal = ıskillDal;
        }

        public List<Skill> GetList()
        {
            return _ıskillDal.List();
        }
    }
}
