using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using vrbit.wsapi.ticket.Model;
using vrbit.wsapi.ticket.Model.Base;

namespace vrbit.wsapi.ticket.Repository.Implementations
{
    public class RepositoryImpl<T> : IRepository<T> where T : BaseEntity
    {

        private readonly TicketContext _ticketContext;
        private DbSet<T> dataset;

        public RepositoryImpl(TicketContext context)
        {
            _ticketContext = context;
            dataset = _ticketContext.Set<T>();
        }

        public T Create(T obj)
        {
            try
            {
                dataset.Add(obj);
                _ticketContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return obj;
        }

        public void Delete(long id)
        {
            var check = FindById(id);

            if (check == null)
                return;

            try
            {
                dataset.Remove(check);
                _ticketContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<T> FindAll()
        {
            List<T> obj = dataset.ToList();

            return obj;
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id == id);
        }

        public T Update(T obj)
        {
            var check = FindById(obj.Id);

            if (check == null)
                return null;

            try
            {
                _ticketContext.Entry(check).CurrentValues.SetValues(obj);
                _ticketContext.SaveChanges();
                return check;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
