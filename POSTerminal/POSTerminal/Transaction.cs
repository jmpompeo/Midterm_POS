using System;
using System.Collections.Generic;
using System.Text;
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

        public PaymentType SelectPayment(string paymentType)
        {


            return (paymentType.ToLower()) switch
            {
                "cash" => PaymentType.cash,
                "credit" => PaymentType.credit,
                "check" => PaymentType.check,
                _ => throw new Exception(nameof(paymentType)),
            };
        }

        public decimal UseCash( decimal cashGiven)
        {
            return cashGiven - OrderAmount;
        }

        public string UseCredit()
        {
            Console.WriteLine("Please enter your card number: ");
            var cardNum = Console.ReadLine();
            Console.WriteLine("Please enter expiration date: ");
            var expDate = Console.ReadLine();
            Console.WriteLine("Please enter your CVV: ");
            var cvvNum = Console.ReadLine();

            for (int i = 10; i > 0; i--)
            {
                Thread.Sleep(500);
                Console.WriteLine("...");
            }
            
            return "APPROVED" + "\r\n"  + "Thank you for shopping with us! ";
        }

        public void UseCheck()
        {

        }
    }
}
