using System;
namespace DevFreela.Core.DTOs
{
    public class PaymentInfoDTO
    {
        public PaymentInfoDTO(int id, string creditCardNumber, string cVV, string ownerCreditCardName, decimal amount, string expiresAt)
        {
            Id = id;
            CreditCardNumber = creditCardNumber;
            CVV = cVV;
            OwnerCreditCardName = ownerCreditCardName;
            Amount = amount;
            ExpiresAt = expiresAt;
        }

        public int Id { get; private set; }
        public string CreditCardNumber { get; private set; }
        public string CVV { get; private set; }
        public string OwnerCreditCardName { get; private set; }
        public decimal Amount { get; private set; }
        public string ExpiresAt { get; private set; }
    }
}

