using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Context;

public static class DataSeeder
{
    public static async Task SeedAsync(DataContext context)
    {
        if (!context.Companies.Any())
        {
            // Company
            var company = new Company
            {
                Name = "Demo Company",
                Email = "demo@business.com",
                PhoneNumber = "+31612345678",
                Address = "123 Demo street"
            };

            // Users
            var users = new List<User>
            {
                new User {Username = "Superadmin", Email = "superadmin@business.com", PasswordHash = "hashedpassword", Company = company, Role = UserRole.SuperAdmin},
                new User {Username = "Admin", Email = "admin@business.com", PasswordHash = "hashedpassword", Company = company, Role = UserRole.Admin},
                new User {Username = "Keyuser", Email = "keyuser@business.com", PasswordHash = "hashedpassword", Company = company, Role = UserRole.KeyUser},
                new User {Username = "User", Email = "user@business.com", PasswordHash = "hashedpassword", Company = company, Role = UserRole.User}
            };

            // Products
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 1200.00m, Company = company },
                new Product { Name = "Mouse", Price = 24.99m, Company = company },
                new Product { Name = "Keyboard", Price = 45.50m, Company = company },
                new Product { Name = "Screen", Price = 100.99m, Company = company },
                new Product { Name = "Chair", Price = 80.97m, Company = company },
                new Product { Name = "Calculator", Price = 19.99m, Company = company },
                new Product { Name = "Charger", Price = 19.99m, Company = company },
                new Product { Name = "Doorbell", Price = 50.10m, Company = company },
                new Product { Name = "Sponge", Price = 4.99m, Company = company },
                new Product { Name = "Chocolate", Price = 0.99m, Company = company }
            };

            // Customers
            var customers = new List<Customer>
            {
                new Customer { FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", Company = company },
                new Customer { FirstName = "Bob", LastName = "Jones", Email = "bob@example.com", Company = company },
                new Customer { FirstName = "Chris", LastName = "Brown", Email = "chris@example.com", Company = company },
                new Customer { FirstName = "Karen", LastName = "Smith", Email = "karen@example.com", Company = company },
                new Customer { FirstName = "Ivan", LastName = "Johnson", Email = "ivan@example.com", Company = company },
                new Customer { FirstName = "Richard", LastName = "Miller", Email = "richard@example.com", Company = company },
                new Customer { FirstName = "Jeff", LastName = "Walton", Email = "jeff@example.com", Company = company },
                new Customer { FirstName = "Marc", LastName = "Wilson", Email = "marc@example.com", Company = company },
                new Customer { FirstName = "Tom", LastName = "Davis", Email = "tom@example.com", Company = company },
                new Customer { FirstName = "Charles", LastName = "King", Email = "charles@example.com", Company = company }
            };

            // Transactions
            var transactions = new List<Transaction>();
            var lineItems = new List<TransactionLineItem>();

            // Create random transactions
            var random = new Random();
            int numberOfRandomTransactions = 100;

            for (int i = 0; i < numberOfRandomTransactions; i++)
            {
                // Pick a random customer
                var customer = customers[random.Next(customers.Count)];

                // Pick a few random products
                var selectedProducts = products.OrderBy(_ => random.Next()).Take(random.Next(1, 4)).ToList();

                // Create a transaction
                var transaction = new Transaction
                {
                    Customer = customer,
                    TransactionDate = DateTime.UtcNow.AddDays(-random.Next(1, 30)),
                    PaymentMethod = random.Next(2) == 0 ? "Credit Card" : "Cash",
                    Notes = random.Next(2) == 0 ? null : "Thank you for your purchase!"
                };

                // Determine the total quantity of a transaction
                decimal total = 0;

                foreach (var product in selectedProducts)
                {
                    var quantity = random.Next(1, 5);
                    var lineItem = new TransactionLineItem
                    {
                        Quantity = quantity,
                        UnitPrice = product.Price,
                        Transaction = transaction,
                        Product = product
                    };

                    total += product.Price * quantity;
                    lineItems.Add(lineItem);
                }

                // Add total amount to transactions
                transaction.TotalAmount = total;
                transactions.Add(transaction);
            }

            context.Companies.Add(company);
            context.Users.AddRange(users);
            context.Products.AddRange(products);
            context.Customers.AddRange(customers);
            context.Transactions.AddRange(transactions);
            context.TransactionLineItems.AddRange(lineItems);

            await context.SaveChangesAsync();
        }
    }
}
