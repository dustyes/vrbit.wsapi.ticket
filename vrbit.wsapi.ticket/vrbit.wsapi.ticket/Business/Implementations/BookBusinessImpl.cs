using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrbit.wsapi.ticket.Model;
using vrbit.wsapi.ticket.Repository;

namespace vrbit.wsapi.ticket.Business.Implementations
{
    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _ticketRepository;

        public BookBusinessImpl(IRepository<Book> repository)
        {
            _ticketRepository = repository;
        }

        public Book Create(Book book)
        {
            return _ticketRepository.Create(book);
        }

        public void Delete(long id)
        {
            _ticketRepository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _ticketRepository.FindAll();
        }

        public Book FindById(long id)
        {
            return _ticketRepository.FindById(id);
        }

        public Book Update(Book book)
        {
            if (book == null)
                return null;

            return _ticketRepository.Update(book);
        }
    }
}
