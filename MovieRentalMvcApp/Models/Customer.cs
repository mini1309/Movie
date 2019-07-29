using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalMvcApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Customer Name is mandatory")]
        [StringLength(50)]
        //[RegularExpression("Hello")]
        [Display(Name ="CustomerName")]
        public string Name { get; set; }
        [Display(Name ="DoB")]
        [Min18YearsIfAMember]
        public bool IsSubscribedToNewsLetter  { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name ="MembershipTypes")]
        public byte MembershipTypeId { get; set; }
        public DateTime DoB { get; set; }
    }
}