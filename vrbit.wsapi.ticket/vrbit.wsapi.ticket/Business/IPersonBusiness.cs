using System.Collections.Generic;
using vrbit.wsapi.ticket.Data.VO;
using vrbit.wsapi.ticket.Model;

namespace vrbit.wsapi.ticket.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
