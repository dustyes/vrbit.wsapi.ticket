using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vrbit.wsapi.ticket.Model;

namespace vrbit.wsapi.ticket.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);

    }
}
