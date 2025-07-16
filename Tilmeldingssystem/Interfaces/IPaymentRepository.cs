using Tilmeldingssystem.Models;

namespace Tilmeldingssystem.Interfaces
{
    /// <summary>
    /// Repository interface for managing Payment entities.
    /// Provides methods to retrieve, add, update, delete payments,
    /// and save changes to the underlying data store.
    /// </summary>
    public interface IPaymentRepository
    {
        /// <summary>
        /// Retrieves all payments.
        /// </summary>
        /// <returns>An enumerable collection of Payment objects.</returns>
        IEnumerable<Payment> GetAllPayments();

        /// <summary>
        /// Retrieves a payment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the payment.</param>
        /// <returns>The Payment object if found; otherwise, null.</returns>
        Payment GetPaymentById(int id);

        /// <summary>
        /// Adds a new payment to the repository.
        /// </summary>
        /// <param name="payment">The Payment object to add.</param>
        void AddPayment(Payment payment);

        /// <summary>
        /// Updates an existing payment.
        /// </summary>
        /// <param name="payment">The Payment object with updated information.</param>
        void UpdatePayment(Payment payment);

        /// <summary>
        /// Deletes a payment by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the payment to delete.</param>
        void DeletePayment(int id);

        /// <summary>
        /// Saves all pending changes to the data store.
        /// </summary>
        /// <returns>True if the save operation was successful; otherwise, false.</returns>
        bool SaveChanges();
    }
}
