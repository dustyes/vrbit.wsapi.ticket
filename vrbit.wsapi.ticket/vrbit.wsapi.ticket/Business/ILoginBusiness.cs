using System.Collections.Generic;
using vrbit.wsapi.ticket.Data.VO;
using vrbit.wsapi.ticket.Model;

namespace vrbit.wsapi.ticket.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(User user);
    }
}
