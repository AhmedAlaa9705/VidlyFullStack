using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.DTO
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [StringLength(255)]
        
        public string Name { get; set; }

        public bool IsSubscribe { get; set; }

        public byte MemberShipTypeId { get; set; }
        public MemberShipTypeDto MemberShipType { get; set; }
                                           //  [Min18Years]
        public DateTime? Birthdate { get; set; }
    }
}