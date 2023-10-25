using MortgageCalc.Models;

namespace MortgageCalc.Helpers
{
    public class LoanHelper
    {
        public Loan GetPayments(Loan loan)
        {
            //Calculate my monthly payment
            loan.Payment = CalcPayment(loan.Amount, loan.Rate, loan.Term);
            //Create loop from 1 to the term
            var balance = loan.Amount;
            var totalInterest = 0.0m;
            var monthlyInterest = 0.0m;
            var monthlyPrincipal = 0.0m;
            var monthlyRate = CalcMonthlyRate(loan.Rate);

            //Loop over each month until we reach the term of the loan
            for (int month = 1; month <= loan.Term; month++)
            {
                monthlyInterest = CalcMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterest;
                monthlyPrincipal = loan.Payment - monthlyInterest;
                balance -= monthlyPrincipal;

                LoanPayment loanPayment = new();
                loanPayment.Month = month;
                loanPayment.Payment = loan.Payment;
                loanPayment.MonthlyPrincipal = monthlyPrincipal;
                loanPayment.MonthlyInterest = monthlyInterest;
                loanPayment.TotalInterest = totalInterest;
                loanPayment.Balance = balance;

                //Push the object into the loan model
                loan.Payments.Add(loanPayment);
            }

            loan.TotalInterest = totalInterest;
            loan.TotalCost = loan.Amount + totalInterest;

            return loan;
            //Calculate a payment schedule

            //Push payments into the loan

            //Return the loan to the view

            
        }

        private decimal CalcPayment(decimal amount, decimal rate, int term)
        {

            var monthlyRate = CalcMonthlyRate(rate);
            var rateD = Convert.ToDouble(monthlyRate);
            var amountD = Convert.ToDouble(amount);
            var paymentD = (amountD * rateD) / (1 - Math.Pow(1 + rateD, -term));


            return Convert.ToDecimal(paymentD);
        }


        private decimal CalcMonthlyRate(decimal rate)
        {
            return rate / 1200;
        }
        
            private decimal CalcMonthlyInterest(decimal balance, decimal monthlyRate)
        {
            return balance * monthlyRate;
        }
            


    }
}