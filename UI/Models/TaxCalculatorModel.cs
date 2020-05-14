using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UI.Models
{
    public class TaxCalculatorModel
    {
        [Required(ErrorMessage = "Please enter a valid postal code")]
        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please enter a valid annual income")]
        [Display(Name = "Annual Income")]
        [Range(1, 99999999999)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AnnualIncome { get; set; }

        public string ResponseMessage { get; set; } 
    }
}
