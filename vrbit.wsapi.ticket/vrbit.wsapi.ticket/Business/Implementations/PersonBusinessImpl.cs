using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrbit.wsapi.ticket.Data.ConvertersImpl;
using vrbit.wsapi.ticket.Data.VO;
using vrbit.wsapi.ticket.Model;
using vrbit.wsapi.ticket.Repository;

namespace vrbit.wsapi.ticket.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {

        private IRepository<Person> _ticketRepository;

        private readonly PersonConverter _converter;

        public PersonBusinessImpl(IRepository<Person> repository)
        {
            _ticketRepository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _ticketRepository.Create(personEntity);

            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _ticketRepository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_ticketRepository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_ticketRepository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _ticketRepository.Update(personEntity);

            return _converter.Parse(personEntity);
        }
    }
}
