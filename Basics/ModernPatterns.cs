using OOPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernPatterns
{
    public enum AccountStatus
    {
        Active = 0,
        Frozen = 1
    }

    public class InsufficientBalance : Exception
    {
        public InsufficientBalance() { }
        public InsufficientBalance(string message) : base(message) { }
    }

    public class InvalidAccountNumber : Exception
    {
        public InvalidAccountNumber() { }
        public InvalidAccountNumber(string message) : base(message) { }
    }
    public class BankAccount
    {
        public int AccountNumber { get; }
        public double Balance { get; private set; }
        public AccountStatus Status { get; private set; }
        public BankAccount(int accountNumber, double currentBalance)
        {
            AccountNumber = accountNumber;
            Balance = currentBalance;
            Status = AccountStatus.Active;
        }

        public void Freeze() => Status = AccountStatus.Frozen;

        public void Credit(double amount)
        {
            Balance += amount;
        }

        public void Debit(double amount)
        {
            if (Balance < amount)
                throw new InsufficientBalance("Insufficient balance");

            Balance -= amount;
        }
    }

    public interface IAccountRepository
    {
        BankAccount GetByAccountNumber(int accountNumber);
        void Update(BankAccount account);
    }

    public class InMemoryAccountRepository : IAccountRepository
    {
        private readonly List<BankAccount> _accounts = new()
    {
        new BankAccount(101, 5000),
        new BankAccount(102, 10000)
    };

        public BankAccount GetByAccountNumber(int accountNumber)
        {
            var account = _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
                throw new InvalidAccountNumber("Account not found");

            return account;
        }

        public void Update(BankAccount account)
        {
            // In-memory → nothing required
            // EF Core → tracked automatically
        }
    }

    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        void Commit();
    }

    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public IAccountRepository Accounts { get; }

        public InMemoryUnitOfWork()
        {
            Accounts = new InMemoryAccountRepository();
        }

        public void Commit()
        {
            // In-memory → nothing
            // DB → transaction.Commit()
            Console.WriteLine("Transaction committed");
        }
    }

    public class TransferMoneyCommand
    {
        public int SourceAccount;
        public int TargetAccount;
        public double Amount;
    }

    public class TransferMoneyCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransferMoneyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Handle(TransferMoneyCommand command)
        {
            var source = _unitOfWork.Accounts.GetByAccountNumber(command.SourceAccount);
            var target = _unitOfWork.Accounts.GetByAccountNumber(command.TargetAccount);

            if (source.Status != AccountStatus.Active ||
                target.Status != AccountStatus.Active)
            {
                throw new Exception("Account is frozen");
            }

            source.Debit(command.Amount);
            target.Credit(command.Amount);

            _unitOfWork.Accounts.Update(source);
            _unitOfWork.Accounts.Update(target);

            _unitOfWork.Commit();
        }
    }

    public class GetAccountBalanceQuery
    {
        public int AccountNumber;
    }

    public class GetAccountBalanceQueryHandler
    {
        private readonly IAccountRepository _repository;

        public GetAccountBalanceQueryHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public double Handle(GetAccountBalanceQuery query)
        {
            return _repository
                .GetByAccountNumber(query.AccountNumber)
                .Balance;
        }
    }

    class Program
    {
        static void Main()
        {
            IUnitOfWork uow = new InMemoryUnitOfWork();

            var transferHandler = new TransferMoneyCommandHandler(uow);
            var balanceHandler = new GetAccountBalanceQueryHandler(uow.Accounts);

            transferHandler.Handle(new TransferMoneyCommand
            {
                SourceAccount = 101,
                TargetAccount = 102,
                Amount = 2000
            });

            Console.WriteLine("Balance 101: " +
                balanceHandler.Handle(new GetAccountBalanceQuery { AccountNumber = 101 }));

            Console.WriteLine("Balance 102: " +
                balanceHandler.Handle(new GetAccountBalanceQuery { AccountNumber = 102 }));
        }
    }

}
