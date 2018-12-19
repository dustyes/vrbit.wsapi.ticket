using System;
using System.Runtime.Serialization;
using vrbit.wsapi.ticket.Data.VO;

namespace vrbit.wsapi.ticket.Data.VO
{
    [DataContract]
    public class BookVO
    {
        [DataMember (Order=1, Name = "codigo")]
        public long? Id { get; set; }

        [DataMember(Order = 2, Name = "titulo")]
        public string Title { get; set; }

        [DataMember(Order = 3, Name = "autor")]
        public string Author { get; set; }

        [DataMember(Order = 5, Name = "preco")]
        public decimal Price { get; set; }

        [DataMember(Order = 4, Name = "datalancamento")]
        public DateTime LaunchDate { get; set; }
    }
}
