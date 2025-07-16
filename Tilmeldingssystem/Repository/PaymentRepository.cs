using System.Collections.Generic;
using System.Linq;
using Tilmeldingssystem.AppDbcontext;
using Tilmeldingssystem.Interfaces;
using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Repository
{
    /// <summary>
    /// Repository class for managing Payment entities in the database.
    /// Implements CRUD operations and persists changes.
    /// </summary>
    public class PaymentRepository : IPaymentRepository
    {
        private readonly TilmeldingsDbContext _context;

        /// <summary>
        /// Constructor injecting the database context.
        /// </summary>
        /// <param name="context">Database context</param>
        public PaymentRepository(TilmeldingsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new payment and immediately saves changes to the database.
        /// </summary>
        /// <param name="payment">Payment entity to add</param>
        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a payment by id and immediately saves changes if found.
        /// </summary>
        /// <param name="id">Payment id</param>
        public void DeletePayment(int id)
        {
            var payment = GetPaymentById(id);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieves all payments from the database.
        /// </summary>
        /// <returns>List of all payments</returns>
        public IEnumerable<Payment> GetAllPayments()
        {
            return _context.Payments.ToList();
        }

        /// <summary>
        /// Retrieves a payment by its id.
        /// </summary>
        /// <param name="id">Payment id</param>
        /// <returns>Payment entity or null if not found</returns>
        public Payment GetPaymentById(int id)
        {
            return _context.Payments.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Saves all pending changes in the database context.
        /// </summary>
        /// <returns>True if one or more changes were saved</returns>
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        /// <summary>
        /// Updates an existing payment and immediately saves changes to the database.
        /// </summary>
        /// <param name="payment">Payment entity with updated values</param>
        public void UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            _context.SaveChanges();
        }
    }
}
