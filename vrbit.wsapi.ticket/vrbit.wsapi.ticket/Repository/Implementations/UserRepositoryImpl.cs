using System;
using System.Collections.Generic;
using System.Linq;
using vrbit.wsapi.ticket.Model;
using vrbit.wsapi.ticket.Repository;

namespace vrbit.wsapi.ticket.Business.Implementations
{
    public class UserRepositoryImpl : IUserRepository
    {

        private TicketContext _ticketContext;

        public UserRepositoryImpl(TicketContext context)
        {
            _ticketContext = context;
        }

        public User FindByLogin(string login)
        {
            return _ticketContext.Users.SingleOrDefault(p => p.Login.Equals(login));
        }
    }
}
