using System.Diagnostics;
using ContactBook.Interfaces;
using ContactBook.Models;

namespace ContactBook.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;
        public ContactService(AppDbContext context)
        {
            _context = context;
        }
        
        public Contact Add(Contact contact)
        {
            var entity = new Entities.Contact();
            entity.FirstName = contact.FirstName;
            entity.LastName = contact.LastName;
            entity.Email = contact.Email;
            entity.FullName = contact.FirstName + " " + contact.LastName;

            _context.Add(entity);
            _context.SaveChanges();

            return contact;

        }

        public bool Delete(int id)
        {
            var entity = _context.Contacts.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _context.Contacts.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List <Contact> GetAll()
        {
            var entityList = _context.Contacts.ToList();
            var modelList = new List<Contact>();

            foreach (var entity in entityList) {
                var model = new Contact();
                model.Id = entity.Id;
                model.FirstName = entity.FirstName;
                model.LastName = entity.LastName;
                model.Email = entity.Email;

                modelList.Add(model);

            }
            return modelList;

        }

        public Contact GetById(int id)
        {
            var entity = _context.Contacts.FirstOrDefault(e => e.Id == id);

            if (entity != null) {
                var model = new Contact();
                model.Id = entity.Id;
                model.FirstName = entity.FirstName;
                model.LastName = entity.LastName;
                model.Email = entity.Email;
                return model;
            }

            return new Contact();
            
        }

        public Contact Update(Contact contact)
        {
            var entity = _context.Contacts.FirstOrDefault(e => e.Id ==  contact.Id);

            if (entity != null)
            {
                entity.FirstName = contact.FirstName;
                entity.LastName = contact.LastName;
                entity.Email = contact.Email;
                entity.FullName = contact.FirstName + " " + contact.LastName;
                

            }
            _context.SaveChanges();
            return contact;
        }
    }
}
