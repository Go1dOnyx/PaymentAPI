using ResourceAPI.EF.DbContexts;
using ResourceAPI.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceAPI.EF.Repositories
{
    public class PaymentRepository
    {
        private PaymentsContext _paymentContext;
        public PaymentRepository(PaymentsContext dbContext)
        {
            _paymentContext = dbContext;
        }
        public int Create(Payment payMethod)
        {
            _paymentContext.Add(payMethod);
            _paymentContext.SaveChanges();

            return payMethod.PaymentId;
        }
        public int Update(Payment payment) 
        {
            Payment getPayMethod = _paymentContext.Payments.Find(payment.PaymentId)!;

            getPayMethod.PaymentId = payment.PaymentId;
            getPayMethod.CardNum = payment.CardNum;
            getPayMethod.CardholderName = payment.CardholderName;
            getPayMethod.ExpirationDate = payment.ExpirationDate;
            getPayMethod.SecurityNum = payment.SecurityNum;
            getPayMethod.Amount = payment.Amount;
            getPayMethod.CardType = payment.CardType;
            getPayMethod.Status = payment.Status;

            _paymentContext.SaveChanges();

            return getPayMethod.PaymentId;
        }
        public bool Delete(int payId) 
        {
            Payment delPay = _paymentContext.Payments.Find(payId)!;
            _paymentContext.Remove(delPay);
            _paymentContext.SaveChanges();

            return true;
        }
        public List<Payment> GetAllPayments() 
        {
            List<Payment> getPayments = _paymentContext.Payments.ToList();
            return getPayments;
        }
        public Payment GetPaymentById(int payId) 
        {
            Payment getPay = _paymentContext.Payments.Find(payId)!;
            return getPay;
        }
    }
}
