﻿namespace MortgageCalc.Models
{
    public class Loan
    {
        public decimal Amount { get; set; }

        public decimal Rate { get; set; }

        public int Term { get; set; }

        public decimal Payment { get; set; }

        public decimal TotalIntrest { get; set; }

        public decimal TotalCost { get; set; }
    }
}
