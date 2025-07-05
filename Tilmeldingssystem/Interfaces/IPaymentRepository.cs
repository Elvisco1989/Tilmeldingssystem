using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Interfaces
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPayments();
        Payment GetPaymentById(int id);
        void AddPayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(int id);
        bool SaveChanges();
    }
}
