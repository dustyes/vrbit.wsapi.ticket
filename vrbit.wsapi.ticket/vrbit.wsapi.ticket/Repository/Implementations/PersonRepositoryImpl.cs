using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrbit.wsapi.ticket.Model;
using vrbit.wsapi.ticket.Repository;

namespace vrbit.wsapi.ticket.Business.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {

        private TicketContext _ticketContext;

        public PersonRepositoryImpl(TicketContext context)
        {
            _ticketContext = context;
        }


        public Person Create(Person person)
        {
            try
            {
                _ticketContext.Add(person);
                _ticketContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return person;
        }

        public void Delete(long id)
        {
            var personcheck = FindById((int)id);

            if (personcheck == null)
                return;

            try
            {
                _ticketContext.Remove(personcheck);
                _ticketContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            List<Person> persons = _ticketContext.Persons.ToList();

            return persons;
        }

        public Person FindById(long id)
        {
            return _ticketContext.Persons.SingleOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            if (person.Id == null)
                return null;

            var personcheck = FindById((int)person.Id);

            if (personcheck == null)
                return new Person();

            try
            {
                _ticketContext.Entry(personcheck).CurrentValues.SetValues(person) ;
                _ticketContext.SaveChanges();
                return personcheck;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
