namespace Online_banking.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Postal> Postals { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }


        /// <summary>
        /// The user will represent the customer.
        /// </summary>
        public class User
        {
            [Key]
            public int pID { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string address { get; set; }
            public string postalCode { get; set; }
            public string phoneNumber { get; set; }
            public string email { get; set; }
            public string password { get; set; }

            public virtual Postal city { get; set; }
            public virtual List<Account> accounts { get; set; }
        }

        public class Account
        {
            [Key]
            public int aID { get; set; }
            public string name { get; set; }
            public AccountType accountType { get; set; }
            public double balance { get; set; }

            public virtual List<Transaction> transaction { get; set; }
        }

        public class Transaction
        {
            [Key]
            public int tID { get; set; }
            public string date { get; set; }
            public Account toAccount { get; set; }
            public double amount { get; set; }
            public string message { get; set; }
            public bool isTransferred { get; set; }
        }

        public class Postal
        {
            [Key]
            public string postalCode { get; set; }
            public string city { get; set; }
        }


        public class AccountType
        {
            [Key]
            public int accTypeID { get; set; }
            public bool card { get; set; }
            public double interest { get; set; }
            public double limit {get; set;}
            public double yearlyFee { get; set; }
        }
    }
}
