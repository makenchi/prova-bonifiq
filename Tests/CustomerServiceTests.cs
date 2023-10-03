using ProvaPub.Repository;
using ProvaPub.Services;
using Xunit;

namespace ProvaPub.Tests
{
    public class CustomerServiceTests
    {
        private readonly TestDbContext _context;
        public CustomerServiceTests(TestDbContext context)
        {
            _context = context;
        }
        [Fact]
        public void ListCustomers_ReturnsCustomerList()
        {
            // Arrange
            using (var context = _context)
            {
                var service = new CustomerService(context);

                // Act
                var result = service.ListCustomers(1);

                // Assert
                Assert.NotNull(result);
                Assert.True(result.Customers.Count > 0);
            }
        }

        [Fact]
        public async Task CanPurchase_ValidCustomerAndPurchaseValue_ReturnsTrue()
        {
            // Arrange
            using (var context = _context)
            {
                var service = new CustomerService(context);
                var customerId = 1;
                var purchaseValue = 50.0m;

                // Act
                var result = await service.CanPurchase(customerId, purchaseValue);

                // Assert
                Assert.True(result);
            }
        }

        [Fact]
        public async Task CanPurchase_InvalidCustomer_ReturnsFalse()
        {
            // Arrange
            using (var context = _context)
            {
                var service = new CustomerService(context);
                var customerId = 999;
                var purchaseValue = 50.0m;

                // Act
                var result = await service.CanPurchase(customerId, purchaseValue);

                // Assert
                Assert.False(result);
            }
        }

        [Fact]
        public async Task CanPurchase_ExceedsMonthlyLimit_ReturnsFalse()
        {
            // Arrange
            using (var context = _context)
            {
                var service = new CustomerService(context);
                var customerId = 1;
                var purchaseValue = 50.0m;

                // Act
                var result = await service.CanPurchase(customerId, purchaseValue);

                // Assert
                Assert.False(result);
            }
        }
    }
}
