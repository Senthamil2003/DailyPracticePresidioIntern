using AtmApplicationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AtmApplicationApp.Context
{
    public class AtmContext:DbContext
    {
        public AtmContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions {  get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { UserId = 101, Name = "John", Phone = "1234567890", Email = "hogn@gmail.com" },
                new Customer() { UserId = 102, Name = "Ram", Phone = "1234567890", Email = "ram@gmail.com" },
                new Customer() { UserId = 103, Name = "Bimu", Phone = "1234567890", Email = "bimu@gmail.com" },
                new Customer() { UserId = 104, Name = "Himu", Phone = "1234567890", Email = "himu@gmail.com" },
                new Customer() { UserId = 105, Name = "Somu", Phone = "1234567890", Email = "somu@gmail.com" }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account() { AccountNumber = 12345678901, Balance = 52000, UserId = 101},
                new Account() { AccountNumber = 09876543210, Balance = 98000, UserId = 102},
                new Account() { AccountNumber = 98765432198, Balance = 78000, UserId = 103 },
                new Account() { AccountNumber = 23456987623, Balance = 91000, UserId = 104 },
                new Account() { AccountNumber = 76575687653, Balance = 88000, UserId = 105 }
            );

            modelBuilder.Entity<Card>().HasData(
                new Card() { CardNumber = 1234569791882006, PIN = 4466, AccountNumber = 12345678901},
                new Card() { CardNumber = 1234569791882007, PIN = 5782, AccountNumber = 09876543210},
                new Card() { CardNumber = 1234569791882008, PIN = 1289, AccountNumber = 98765432198},
                new Card() { CardNumber = 1234569791882009, PIN = 2522, AccountNumber = 23456987623},
                new Card() { CardNumber = 1234569791882001, PIN = 7319, AccountNumber = 76575687653}
            );
        }
    }
}
