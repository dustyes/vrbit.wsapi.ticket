using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrbit.wsapi.ticket.Model;
using vrbit.wsapi.ticket.Repository;

namespace vrbit.wsapi.ticket.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IPersonRepository _ticketRepository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _ticketRepository = repository;
        }

        public Person Create(Person person)
        {
            return _ticketRepository.Create(person);
        }

        public void Delete(long id)
        {
            _ticketRepository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _ticketRepository.FindAll();
        }

        public Person FindById(long id)
        {
            return _ticketRepository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _ticketRepository.Update(person);
        }
    }
}
