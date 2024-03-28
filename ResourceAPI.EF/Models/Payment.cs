using System;
using System.Collections.Generic;

namespace ResourceAPI.EF.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int UserID { get; set; }

    public int CardNum { get; set; }

    public string CardholderName { get; set; } = null!;

    public DateOnly ExpirationDate { get; set; }

    public int SecurityNum { get; set; }

    public decimal Amount { get; set; }

    public string CardType { get; set; } = null!;

    public bool Status { get; set; }
    public Payment(int payId, int userId, int cardNum, string name, DateOnly exp, int securityNum, string cardType, bool status) 
    {
        PaymentId = payId;
        UserID = userId;
        CardNum = cardNum;
        CardholderName = name;
        ExpirationDate = exp;
        SecurityNum = securityNum;
        CardType = cardType;
        Status = status;
    }
    public Payment() { }
}
