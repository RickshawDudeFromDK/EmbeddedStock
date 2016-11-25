using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmbeddedStock.Models.Loan
{
    public class LoanViewModel
    {
        public int Id { get; set; }

        [DisplayName("Telephone Number")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNumber { get; set; }

        [DisplayName("Email")]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Student Number")]
        [Required(AllowEmptyStrings = false)]
        public string StudentNumber { get; set; }

        [DisplayName("Name")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }

        [DisplayName("Component")]
        public ComponentViewModel Component { get; set; }

        [DisplayName("Component")]
        [Required]
        public int ComponentId { get; set; }

        [DisplayName("Loan Date")]
        [DataType(DataType.Date)]
        public DateTime LoanDate { get; set; }

        [DisplayName("Return Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        [DisplayName("Is Email Sent")]
        public bool IsEmailSent { get; set; }

        public DateTime ReservationDate { get; set; }
    }
}