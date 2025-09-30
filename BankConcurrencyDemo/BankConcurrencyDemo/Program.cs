using BankConcurrencyDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace BankConcurrencyDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();
            await context.Database.EnsureCreatedAsync();

            // Seed Data
            if (!context.BankAccounts.Any())
            {
                context.BankAccounts.Add(new BankAccount
                {
                    AccountHolder = "Fady",
                    Balance = 1000
                });
                await context.SaveChangesAsync();
            }

            Console.WriteLine("Select the synchronization type:");
            Console.WriteLine("1 - Optimistic Concurrency");
            Console.WriteLine("2 - Pessimistic Concurrency");
            var choice = Console.ReadLine();

            if (choice == "1")
                await RunOptimisticConcurrency();
            else
                await RunPessimisticConcurrency();
        }

        // Optimistic Concurrency Example
        static async Task RunOptimisticConcurrency()
        {
            using var context1 = new AppDbContext();
            using var context2 = new AppDbContext();

            // User A & User B يقروا نفس الحساب
            var accountA = await context1.BankAccounts.FirstAsync();
            var accountB = await context2.BankAccounts.FirstAsync();

            // User A يسحب 200
            accountA.Balance -= 200;
            await context1.SaveChangesAsync();
            Console.WriteLine("User A withdrew 200. New balance: " + accountA.Balance);

            // User B يحاول يسحب 300 بناءً على الرصيد القديم
            accountB.Balance -= 300;
            try
            {
                await context2.SaveChangesAsync();
                Console.WriteLine("User B withdrew 300. New balance:" + accountB.Balance);
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine(" Conflict! The data has changed since you read it. Read again and try again.");
            }
        }

        //  Pessimistic Concurrency Example
        static async Task RunPessimisticConcurrency()
        {
            using var context = new AppDbContext();
            using var transaction = await context.Database.BeginTransactionAsync();

            // User A بياخد الحساب بـ Lock
            var account = await context.BankAccounts
                .FromSqlRaw("SELECT * FROM BankAccounts WITH (UPDLOCK, ROWLOCK) WHERE Id = {0}", 1)
                .FirstAsync();

            Console.WriteLine("Current balance:" + account.Balance);

            // User A يسحب 200
            account.Balance -= 200;
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

            Console.WriteLine("User A withdrew 200. New balance: " + account.Balance);
        }

    }
}
