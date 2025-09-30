using System.ComponentModel.DataAnnotations;

namespace BankConcurrencyDemo
{
    // Model
    public class BankAccount
    {
        public int Id { get; set; }
        public string AccountHolder { get; set; }
        public decimal Balance { get; set; }

        [Timestamp] // Optimistic Concurrency Token
        public byte[] RowVersion { get; set; }
    }
}