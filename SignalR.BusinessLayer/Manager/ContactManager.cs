using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Manager
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactdal;

        public ContactManager(IContactDal contactdal)
        {
            _contactdal = contactdal;
        }

        public void TAdd(Contact entity)
        {
            _contactdal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactdal.Delete(entity);
        }

        public Contact TGetById(int id)
        {
            return _contactdal.GetById(id);
        }

        public List<Contact> TGetListAll()
        {
            return _contactdal.GetListAll();
        }

        public void TUpdate(Contact entity)
        {
           _contactdal.Update(entity);
        }
    }
}
