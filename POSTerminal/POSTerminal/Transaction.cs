using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace POSTerminal
{
    public class Transaction
    {
        public Transaction(decimal orderAmount)
        {
            OrderAmount = orderAmount;
        }

        public Transaction()
        {

        }

        public decimal OrderAmount { get; }
       

        public void SelectPayment(string paymentType, decimal cashGiven)
        {
            switch (paymentType.ToLower())
            {
                case "cash":
                    UseCash(cashGiven);
                    break;
                case "credit":
                    UseCredit();
                    break;
                case "check":
                    UseCheck();
                    break;
                default:
                    throw new ArgumentException(nameof(paymentType));
            }
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

        private bool ValidateLicense(string license)
        {
            var reg = new Regex(@"^[A-Z]*\d{1,16}");

            if (reg.IsMatch(license))
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
            string license = null;

            do
            {
                Console.WriteLine("Please enter your driver's license number: ");

            } while (!ValidateLicense(license));

            do
            {
                Console.WriteLine("Please enter a check number: ");
                response = Console.ReadLine();
                
            } while (!ValidateCheck(response));
        }

        public List<Product> GetLineTotal(List<Product> products)
        {
            
            var lineTotal = new List<Product>();

            foreach (var product in products)
            {
                var total = product.Price * product.Quantity;
                lineTotal.Add(new Product { Name = product.Name, Quantity = product.Quantity, Price = product.Price, Total = total });
            }

            return lineTotal;
        }

        public decimal CalculateTotal(List<Product> lineTotal)
        {
            decimal salesTax = .06M;
            decimal subTotal = 0;

            foreach (var item in lineTotal)
            {
                 subTotal += item.Total;
            }

            return (subTotal * salesTax) + subTotal;
        }
    }
}
