using RealEstate.API.Application.Common.Constants;
using RealEstate.API.Application.DTO;
using System;
using System.Collections.Generic;

namespace RealEstate.API.Application.Services
{
    public class LoanService
    {
        public LoanDto GenerateSchedule(decimal? interestRate, string currency, decimal loanAmount, decimal monthlyPayment)
        {
            if (interestRate == null)
            {
                if (currency == Currency.ALL)
                {
                    interestRate = LoanParameters.InterestRateALL;
                }
                else if (currency == Currency.EUR)
                {
                    interestRate = LoanParameters.InterestRateEUR;
                }
            }

            decimal rate = (interestRate ?? 0) / 12m; // monthly rate
            int termMonths = 0;
            decimal balance = loanAmount;
            var installments = new List<LoanInstallment>();
            DateTime startDate = DateTime.Today;
            DateTime dueDate = startDate;

            // Calculate number of months needed
            if (rate > 0)
            {
                // n = -log(1 - r*P/A) / log(1 + r)
                termMonths = (int)Math.Ceiling(-Math.Log(1 - ((double)rate * (double)loanAmount) / (double)monthlyPayment) / Math.Log(1 + (double)rate));
            }
            else
            {
                termMonths = (int)Math.Ceiling(loanAmount / monthlyPayment);
            }

            for (int i = 1; i <= termMonths; i++)
            {
                decimal interest = Math.Round(balance * rate, 2);
                decimal principal = Math.Round(Math.Min(monthlyPayment - interest, balance),2);
                decimal totalPayment = principal + interest;
                dueDate = dueDate.AddMonths(1);

                installments.Add(new LoanInstallment
                {
                    InstallmentNumber = i,
                    Principal = principal,
                    Interest = interest,
                    TotalPayment = totalPayment,
                    DueDate = dueDate
                });
                balance -= principal;
                if (balance <= 0) break;
            }

            return new LoanDto
            {
                Amount = loanAmount,
                InterestRate = interestRate ?? 0,
                TermMonths = installments.Count,
                StartDate = startDate,
                EndDate = dueDate,
                MonthlyPayment = monthlyPayment,
                Currency = currency,
                Installments = installments
            };
        }

        public LoanDto GenerateSchedule(decimal? interestRate, string currency, decimal loanAmount, int termMonths)
        {
            if (interestRate == null)
            {
                if (currency == Currency.ALL)
                {
                    interestRate = LoanParameters.InterestRateALL;
                }
                else if (currency == Currency.EUR)
                {
                    interestRate = LoanParameters.InterestRateEUR;
                }
            }

            decimal rate = (interestRate ?? 0) / 12m; // monthly rate
            decimal monthlyPayment;
            if (rate > 0)
            {
                // A = P * r * (1 + r)^n / ((1 + r)^n - 1)
                double r = (double)rate;
                double n = termMonths;
                double P = (double)loanAmount;
                monthlyPayment = (decimal)(P * r * Math.Pow(1 + r, n) / (Math.Pow(1 + r, n) - 1));
            }
            else
            {
                monthlyPayment = loanAmount / termMonths;
            }

            decimal balance = loanAmount;
            var installments = new List<LoanInstallment>();
            DateTime startDate = DateTime.Today;
            DateTime dueDate = startDate;

            for (int i = 1; i <= termMonths; i++)
            {
                decimal interest = Math.Round(balance * rate, 2);
                decimal principal = Math.Round(Math.Min(monthlyPayment - interest, balance),2);
                decimal totalPayment = principal + interest;
                dueDate = dueDate.AddMonths(1);
                installments.Add(new LoanInstallment
                {
                    InstallmentNumber = i,
                    Principal = principal,
                    Interest = interest,
                    TotalPayment = totalPayment,
                    DueDate = dueDate
                });
                balance -= principal;
                if (balance <= 0) break;
            }

            return new LoanDto
            {
                Amount = loanAmount,
                InterestRate = interestRate ?? 0,
                TermMonths = termMonths,
                StartDate = startDate,
                EndDate = dueDate,
                MonthlyPayment = Math.Round(monthlyPayment, 2),
                Currency = currency,
                Installments = installments
            };
        }
    }
}
