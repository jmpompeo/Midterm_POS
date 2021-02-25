using System;
using System.Collections.Generic;
using System.Text;

namespace POSTerminal
{
    public interface IPayment
    {

        PaymentType SelectPayment(string paymentType, decimal cashGiven);


    }
}
