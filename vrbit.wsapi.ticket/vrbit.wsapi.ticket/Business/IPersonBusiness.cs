﻿using System.Collections.Generic;
using vrbit.wsapi.ticket.Model;

namespace vrbit.wsapi.ticket.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
