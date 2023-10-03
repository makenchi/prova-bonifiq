namespace ProvaPub.Services
{
    public interface IPaymentProcessor
    {
        Task ProcessPaymentAsync(string paymentMethod, decimal paymentValue, int customerId);
    }
}
