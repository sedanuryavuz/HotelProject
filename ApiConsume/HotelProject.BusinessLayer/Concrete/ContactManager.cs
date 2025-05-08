﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ContactManager: IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Delete(Contact t)
        {
            _contactDal.Delete(t);
        }

        public Contact GetById(int id)
        {
           return _contactDal.GetById(id);
        }

        public List<Contact> GetList()
        {
         return  _contactDal.GetList();
        }

        public void Insert(Contact t)
        {
           _contactDal.Insert(t);
        }

        public void Update(Contact t)
        {
            _contactDal.Update(t);
        }
    }
}
