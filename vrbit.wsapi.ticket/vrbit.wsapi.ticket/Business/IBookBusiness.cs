using System;
using System.Collections.Generic;
using vrbit.wsapi.ticket.Model;

namespace vrbit.wsapi.ticket.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book book);
        void Delete(long id);
    }
}
