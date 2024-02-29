using System;
using System.Collections.Generic;

namespace ResourceAPI.EF.Models;

public partial class UserPayment
{
    public int UserId { get; set; }

    public int PaymentId { get; set; }

    public virtual Payment Payment { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public UserPayment(int userId, int payId, Payment pay, User user) 
    {
        UserId = userId;
        PaymentId = payId;
        Payment = pay;
        User = user;
    }
    public UserPayment() { }
}
