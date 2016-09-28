using Online_banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Online_banking.Models.ModelContext;

namespace Online_banking
{
    public class DB
    {
        public void initialize_test_data()
        {
            using(var db = new ModelContext())
            {
                DateTime time = new DateTime();

                // accountType
                var newAccountType = new AccountType()
                {
                    card = true,
                    interest = 3.00,
                    limit = 10000,
                    yearlyFee = 0
                };

                // Postalcode
                var postal = new Postal()
                {
                    postalCode = "0707",
                    city = "Oslo"
                };

                // Add user 1
                var user1 = new User()
                {
                    firstname = "Ola",
                    lastname = "Nordmann",
                    address = "Nordmannveien 32",
                    postalCode = "0707",
                    phoneNumber = "07070707",
                    email = "OlaNordmann@example.com",
                    password = "password",
                };

                // User1 account
                var account1 = new Account()
                {
                    name = "Ola Savings account",
                    balance = 10000,
                    accountType = newAccountType
                };

                user1.accounts.Add(account1);

                // Add user 2
                var user2 = new User()
                {
                    firstname = "Kari",
                    lastname = "Nordmann",
                    address = "Nordmannveien 32",
                    postalCode = "0707",
                    phoneNumber = "06060606",
                    email = "KariNordmann@example.com",
                    password = "password",
                };

                // User2 account
                var account2 = new Account()
                {
                    name = "Kari Savings account",
                    balance = 5000,
                    accountType = newAccountType
                };

                user2.accounts.Add(account2);

                // Add user 3
                var user3 = new User()
                {
                    firstname = "Nils",
                    lastname = "Nordmann",
                    address = "Nordmannveien 32",
                    postalCode = "0707",
                    phoneNumber = "05050505",
                    email = "NilsNordmann@example.com",
                    password = "password",
                };

                // User3 account
                var account3 = new Account()
                {
                    name = "Nils Savings account",
                    balance = 2500,
                    accountType = newAccountType
                };

                user3.accounts.Add(account3);

                // Transaction from user 1 account too user 2 account
                var transaction1 = new Transaction()
                {
                    date = time.ToString("MMMM dd, yyyy"),
                    fromAccount = account1,
                    toAccount = account2,
                    amount = 500,
                    message = "Vi er skuls",
                    isTransferred = true
                };
                
                db.Transactions.Add(transaction1);

                // Transaction from user 2 account too user 3 account
                var transaction2 = new Transaction()
                {
                    date = time.ToString("MMMM dd, yyyy"),
                    fromAccount = account2,
                    toAccount = account3,
                    amount = 250,
                    message = "Mat greier",
                    isTransferred = true
                };

                db.Transactions.Add(transaction2);

                // Transaction from user 3 account too user 1 account
                var transaction3 = new Transaction()
                {
                    date = time.ToString("MMMM dd, yyyy"),
                    fromAccount = account3,
                    toAccount = account1,
                    amount = 1500,
                    message = "Nasty stuff",
                    isTransferred = false
                };

                db.Transactions.Add(transaction3);
                db.SaveChanges();
            }
        }
    }
}