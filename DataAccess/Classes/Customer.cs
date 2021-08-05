using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Classes
{
    public class Customer
    {
        public int Id { get; set; }

        
        [StringLength(255)]
        [Required(ErrorMessage ="Please enter customer Name")]
        public string Name { get; set; }

        public bool IsSubscribe { get; set; }

        public MemberShipType MemberShipType { get; set; }
        [Display(Name ="MemberShip Type")]
        public byte MemberShipTypeId { get; set; }
        [Min18Years]
        public DateTime? Birthdate { get; set; }

    }
}
