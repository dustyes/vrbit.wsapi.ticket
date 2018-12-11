using System.Collections.Generic;
using vrbit.wsapi.ticket.Model.Base;

namespace vrbit.wsapi.ticket.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T obj);
        T FindById(long id);
        List<T> FindAll();
        T Update(T obj);
        void Delete(long id);
    }
}
