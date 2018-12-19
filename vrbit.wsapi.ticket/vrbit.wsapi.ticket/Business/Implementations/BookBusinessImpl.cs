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
    public class BookBusinessImpl : IBookBusiness
    {
        private IRepository<Book> _ticketRepository;
        private readonly BookConverter _converter;

        public BookBusinessImpl(IRepository<Book> repository)
        {
            _ticketRepository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _ticketRepository.Create(bookEntity);

            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _ticketRepository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_ticketRepository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_ticketRepository.FindById(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _ticketRepository.Update(bookEntity);

            return _converter.Parse(bookEntity);
        }
    }
}
