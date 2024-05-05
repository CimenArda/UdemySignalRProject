using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.ContactDto
{
    public class ResultContactDto
    {
        public int ID { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }
        public string Mail { get; set; }


        public string FooterDesctiption { get; set; }
    }
}
