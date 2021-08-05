using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class MemberShipType
    {       
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountReate { get; set; }

        public static readonly byte Unkown = 0;
        public static readonly byte Payasyougo = 1;

    }
}
