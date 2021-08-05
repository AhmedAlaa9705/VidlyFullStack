using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Classes;

namespace VidlyFullStack.Models
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
    }
}