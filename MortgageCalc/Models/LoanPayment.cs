using System.ComponentModel.DataAnnotations;

namespace MortgageCalc.Models
{
    public class LoanPayment
    {
        public int Month { get; set; }
        [DisplayFormat(DataFormatString ="{0:C0}", ApplyFormatInEditMode = true)]
        public decimal Payment { get; set; }
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal MonthlyPrincipal { get; set; }
        public decimal MonthlyInterest { get; set; }
        public decimal ToaalInterest { get; set; }
        public decimal Balance { get; set; }

    }
}
