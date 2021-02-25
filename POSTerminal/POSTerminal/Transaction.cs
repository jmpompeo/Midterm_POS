using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace POSTerminal
{
    class Transaction : IPayment
    {

        public Transaction(decimal orderAmount)
        {
            OrderAmount = orderAmount;
        }

        public decimal OrderAmount { get; }

        public PaymentType SelectPayment(string paymentType, decimal cashGiven)
        {
            

            return (paymentType.ToLower()) switch
            {
                "cash" => UseCash(cashGiven),
                "credit" => Paymentype.credit,
                "check" => PaymentType.check,
                _ => throw new Exception(nameof(paymentType)),
            };
        }

        private bool ValidateCheck(string response)
        {
            var reg = new Regex(@"^[0-9]+$");

            if (reg.IsMatch(response))
            {
                return true;
            }

            return false;
            
        }

        private bool ValidateCardNum(string response)
        {
            var cardNumReg = new Regex(@"^\d{15,19}$");

            if (cardNumReg.IsMatch(response))
            {
                return true;
            }

            return false;
        }

        private bool ValidateExpDate(string response)
        {
            var expDateReg = new Regex(@"^\d{4}$");

            if (expDateReg.IsMatch(response))
            {
                return true;
            }

            return false;
        }

        private bool ValidateCVV(string response)
        {
            var cvvReg = new Regex(@"^\d{3,4}$");

            if (cvvReg.IsMatch(response))
            {
                return true;
            }

            return false;
        }

        public decimal UseCash(decimal cashGiven)
        {
            return cashGiven - OrderAmount;
        }

        public string UseCredit()
        {
            string cardNum, expDate, cvvNum;

            do
            {
                Console.WriteLine("Please enter your card number: ");
                cardNum = Console.ReadLine();

            } while (!ValidateCardNum(cardNum));

            do
            {
                Console.WriteLine("Please enter expiration date: ");
                expDate = Console.ReadLine();

            } while (!ValidateExpDate(expDate));

            do
            {
                Console.WriteLine("Please enter your CVV: ");
                cvvNum = Console.ReadLine();
            } while (!ValidateCVV(cvvNum));

            for (int i = 10; i > 0; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("...");
            }
            
            return "APPROVED" + "\r\n"  + "Thank you for shopping with us! ";
        }

        public void UseCheck()
        {
            string response;

            do
            {
                Console.WriteLine("Please enter a check number: ");
                response = Console.ReadLine();
                
            } while (!ValidateCheck(response));
        }
    }
}
