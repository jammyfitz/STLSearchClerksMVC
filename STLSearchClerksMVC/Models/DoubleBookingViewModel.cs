using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace STLSearchClerksMVC.Models
{
    public class DoubleBookingViewModel
    {
        [Required(ErrorMessage = "Booking Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BookingDate { get; set; }
        [Required(ErrorMessage = "Search Clerk is required")]
        public int SearchClerkId { get; set; }
        [Required(ErrorMessage = "Authority is required")]
        public int AuthorityId { get; set; }

        public IList<Authority> Authorities { get; set; }
        public IList<SearchClerk> SearchClerks { get; set; }
    }
}