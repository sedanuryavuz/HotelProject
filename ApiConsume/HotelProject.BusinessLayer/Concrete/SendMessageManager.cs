using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly EfSendMessageDal _efSendMessageDal;

        public SendMessageManager(EfSendMessageDal efSendMessageDal)
        {
            _efSendMessageDal = efSendMessageDal;
        }

        public void TDelete(SendMessage t)
        {
            _efSendMessageDal.Delete(t);
        }

        public SendMessage TGetById(int id)
        {
            return _efSendMessageDal.GetById(id);
        }

        public List<SendMessage> TGetList()
        {
            return _efSendMessageDal.GetList();
        }

        public void TInsert(SendMessage t)
        {
            _efSendMessageDal.Insert(t);
        }

        public int TSendMessageCount()
        {
            return _efSendMessageDal.SendMessageCount();
        }

        public void TUpdate(SendMessage t)
        {
            _efSendMessageDal.Update(t);
        }
    }
}
