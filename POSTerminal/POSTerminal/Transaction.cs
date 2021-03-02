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

        public decimal OrderAmount { get; set; }

        public void SelectPayment(string paymentType)
        {
            switch (paymentType)
            {
                case "cash":

                    UseCash();
                    break;
                case "credit":
                    UseCredit();
                    break;
                case "debit":
                    UseDebit();
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
            else if (String.IsNullOrEmpty(response))
            {
                return false;
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
            else if (String.IsNullOrEmpty(license))
            {
                return false;
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
            else if (String.IsNullOrEmpty(response))
            {
                return false;
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
            else if (String.IsNullOrEmpty(response))
            {
                return false;
            }

            return false;
        }

        private bool ValidatePin(string response)
        {
            var expDateReg = new Regex(@"^\d{4}$");

            if (expDateReg.IsMatch(response))
            {
                return true;
            }
            else if (String.IsNullOrEmpty(response))
            {
                return false;
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
            else if (String.IsNullOrEmpty(response))
            {
                return false;
            }

            return false;
        }

        public void UseCash()
        {
            decimal cash = 0;
            bool isValid;
            decimal cashGiven;
            
            do
            {
                Console.WriteLine("Please enter the amount of cash given");
                isValid = decimal.TryParse(Console.ReadLine(), out cash);

                for (decimal i = cash; i < OrderAmount; i++)
                {
                    Console.WriteLine("PAY UP JASON!! ");
                    cashGiven = decimal.TryParse(Console.ReadLine(), out cashGiven) ? cashGiven : default;
                    cash += cashGiven;
                }

            } while (!isValid);

            

            decimal change = cash - OrderAmount;
            Console.WriteLine($"Your change is: ${Math.Round(change,2)}");
        }

        public void UseCredit()
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

            Console.WriteLine("APPROVED" + "\r\n" + "Thank you for shopping with us! ");
        }

        public void UseDebit()
        { 
            string cardNum, expDate, cvvNum, pinNum;

            do
            {
                Console.Write("Please enter your card number: ");
                cardNum = Console.ReadLine();

            } while (!ValidateCardNum(cardNum));

            do
            {
                Console.Write("Please enter expiration date: ");
                expDate = Console.ReadLine();

            } while (!ValidateExpDate(expDate));

            do
            {
                Console.Write("Please enter your CVV: ");
                cvvNum = Console.ReadLine();
            } while (!ValidateCVV(cvvNum));

            do
            {
                Console.Write("Please enter your pin: ");
                pinNum = Console.ReadLine();

            } while (!ValidatePin(pinNum));

            for (int i = 10; i > 0; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("...");
            }

            Console.WriteLine("APPROVED" + "\r\n" + "Thank you for shopping with us! ");
        }

        public void UseCheck()
        {
            string response;
            string license;

            do
            {
                Console.WriteLine("Please enter your driver's license number: ");
                license = Console.ReadLine();

            } while (!ValidateLicense(license));

            do
            {
                Console.WriteLine("Please enter a check number: ");
                response = Console.ReadLine();

            } while (!ValidateCheck(response));

            Console.WriteLine("Thank you for shopping at CJR Burgers!! Please come again for another delectible treat.");
        }
        public List<Product> GetLineTotal(List<Product> products)
        {
            var lineTotal = new List<Product>();

            Console.WriteLine("Here's what you have ordered: ");

            foreach (var product in products)
            {
                product.Total = product.Price * product.Quantity;
                lineTotal.Add(new Product { Quantity = product.Quantity, Name = product.Name, Price = product.Price, Total = product.Total});
                Console.WriteLine($"{product.Quantity} {product.Name} ");
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

            Console.WriteLine($"Subtotal: ${subTotal}");
            var totalTax = subTotal * salesTax;
            Console.WriteLine($"Taxes: ${Math.Round(totalTax,2)}");
            var grandTotal = totalTax + subTotal;
            Console.WriteLine($"Total with taxes: ${Math.Round(grandTotal,2)}");

            return grandTotal;
        }
    }
}
