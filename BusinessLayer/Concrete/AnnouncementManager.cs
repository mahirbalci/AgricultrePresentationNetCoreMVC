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
    public class AnnouncementManager : IAnnouncementService
    {
       private readonly IAnnouncementDal _annoncementDal;
        public AnnouncementManager(IAnnouncementDal annoncementDal)
        {
            _annoncementDal = annoncementDal;
        }

        

        public void AnnouncementStatusToFalse(int id)
        {
            _annoncementDal.AnnouncementStatusToFalse(id);
        }

        public void AnnouncementStatusToTrue(int id)
        {
            _annoncementDal.AnnouncementStatusToTrue(id);
        }

        public void Delete(Announcement t)
        {
            _annoncementDal.Delete(t);
        }

        public Announcement GetById(int id)
        {
          return  _annoncementDal.GetById(id);
        }

        public List<Announcement> GetListAll()
        {
           return _annoncementDal.GetListAll();
        }

        public void Insert(Announcement t)
        {
            _annoncementDal.Insert(t);
        }

        public void Update(Announcement t)
        {
           _annoncementDal.Update(t);
        }
    }
}
