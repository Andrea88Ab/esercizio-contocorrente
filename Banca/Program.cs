namespace Banca
{

    using System;
    using System.Collections.Generic;

    public class ContoCorrente
    {
        public string AccountHolder { get; private set; }
        public decimal Balance { get; private set; }
        private bool isOpen;


        private ContoCorrente(string accountHolder, decimal initialDeposit)
        {
            AccountHolder = accountHolder;
            Balance = initialDeposit;
            isOpen = true;
        }


        public static ContoCorrente OpenAccount(string accountHolder, decimal initialDeposit)
        {
            if (initialDeposit < 1000)
            {
                Console.WriteLine("Failed to open account: The initial deposit must be at least 1000 euros.");
                return null;
            }
            var newAccount = new ContoCorrente(accountHolder, initialDeposit);
            Console.WriteLine($"Account for {newAccount.AccountHolder} opened with balance: {newAccount.Balance} euros.");
            return newAccount;
        }

        public void Deposit(decimal amount)
        {
            if (!isOpen)
            {
                throw new InvalidOperationException("Account is not open.");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than zero.");
            }
            Balance += amount;
            Console.WriteLine($"Deposited: {amount} euros. New balance: {Balance} euros.");
        }

        public void Withdraw(decimal amount)
        {
            if (!isOpen)
            {
                throw new InvalidOperationException("Account is not open.");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be greater than zero.");
            }
            if (Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds for the withdrawal.");
            }
            Balance -= amount;
            Console.WriteLine($"Withdrew: {amount} euros. Remaining balance: {Balance} euros.");
        }
    }

    class Program
    {
        static List<ContoCorrente> conti = new List<ContoCorrente>();

        static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nBank Account Management System:");
                Console.WriteLine("1. Open a new bank account");
                Console.WriteLine("2. Make a deposit");
                Console.WriteLine("3. Make a withdrawal");
                Console.WriteLine("4. List all bank accounts");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option (1-5): ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        OpenNewAccount();
                        break;
                    case "2":
                        MakeADeposit();
                        break;
                    case "3":
                        MakeAWithdrawal();
                        break;
                    case "4":
                        ListAllAccounts();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void OpenNewAccount()
        {
            Console.Write("Enter the account holder's name: ");
            string accountHolder = Console.ReadLine();

            decimal initialDeposit = 0;
            Console.Write("Enter the initial deposit amount (must be at least 1000 euros): ");
            while (!decimal.TryParse(Console.ReadLine(), out initialDeposit) || initialDeposit < 1000)
            {
                Console.WriteLine("Invalid amount. You must enter a numeric value of at least 1000 euros.");
                Console.Write("Enter the initial deposit amount (must be at least 1000 euros): ");
            }

            var account = ContoCorrente.OpenAccount(accountHolder, initialDeposit);
            if (account != null)
            {
                conti.Add(account);
            }
        }

        static void MakeADeposit()
        {

        }

        static void MakeAWithdrawal()
        {

        }

        static void ListAllAccounts()
        {
            Console.WriteLine("\nListing all accounts:");
            foreach (var account in conti)
            {
                Console.WriteLine($"Account Holder: {account.AccountHolder}, Balance: {account.Balance} euros");
            }
        }
    }




}
