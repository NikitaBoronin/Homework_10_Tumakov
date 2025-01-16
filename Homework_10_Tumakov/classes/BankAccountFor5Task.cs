

namespace Homework_10_Tumakov
{
    class BankAccountFor5Task : IDisposable
    {

        #region Поля
        /// <summary>
        /// Номер счета.
        /// </summary>
        private Guid accountNumber;



        private readonly Queue<BankTransaction> _transactionHistory = new Queue<BankTransaction>();

        /// <summary>
        /// Статическая переменная для генерации уникальных номеров счетов.
        /// </summary>
        //private static int nextAccountNumber = 0;

        /// <summary>
        /// Баланс счета.
        /// </summary>
        private decimal balance;

        /// <summary>
        /// Тип банковского счета.
        /// </summary>
        private BankAccountType accountType;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор, создающий банковский счет с заданным балансом и типом.
        /// </summary>
        /// <param name="balance">Начальный баланс счета.</param>
        /// <param name="type">Тип банковского счета.</param>
        internal BankAccountFor5Task(decimal balance, BankAccountType type, Guid accountNumber)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.accountType = type;
        }

        /// <summary>
        /// Конструктор, создающий банковский счет с заданным балансом.
        /// </summary>
        /// <param name="balance">Начальный баланс.</param>
        internal BankAccountFor5Task(decimal balance, Guid accountNumber)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
        }

        /// <summary>
        /// Конструктор, создающий банковский счет с типом.
        /// </summary>
        /// <param name="type">Тип банковского счета.</param>
        internal BankAccountFor5Task(BankAccountType type, Guid accountNumber)
        {
            this.accountNumber = accountNumber;
            accountType = type;
        }
        /// <summary>
        /// Конструктор по умолчанию, создающий счет с нулевым балансом.
        /// </summary>
        internal BankAccountFor5Task(Guid accountNumber)
        {
            this.accountNumber = accountNumber;
            this.balance = 0;

        }
        #endregion

        #region Переопределение операторов и методов

        public static bool operator ==(BankAccountFor5Task account1, BankAccountFor5Task account2)
        {
            if(ReferenceEquals(account1, account2)) return true;

            if (ReferenceEquals(account1, null) || ReferenceEquals(account2, null)) return false;

            if (account1.balance == account2.balance && account1.accountType == account2.accountType)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(BankAccountFor5Task account1, BankAccountFor5Task account2)
        {
            return !(account1 == account2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;

            var account = (BankAccountFor5Task)obj;

            return balance == account.balance && accountType == account.accountType;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(balance, accountType);
        }

        public override string ToString()
        {
            return $"Account ID: {accountNumber} balance: {balance} accountType: {accountType}";
        }

        #endregion

        #region Методы



        

        public Guid GetId() { return accountNumber; }

        /// <summary>
        /// Метод для вывода информации о банковском счете.
        /// </summary>
        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}\nБаланс: {balance}\nТип банковского счета: {accountType}");
        }

        /// <summary>
        /// Метод записывающий транзакции в файл.
        /// </summary>
        public void WriteTransactionsToFile()
        {
            try
            {

                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
                string filePath = Path.Combine(projectDirectory, "transactions.txt");


                using (StreamWriter writer = new StreamWriter(filePath, append: false))
                {
                    foreach (var transaction in _transactionHistory)
                    {
                        writer.WriteLine(transaction.ToString());
                    }
                }


                _transactionHistory.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при записи транзакций в файл: {ex.Message}");
            }
            finally
            {
                GC.SuppressFinalize(this);
            }


        }


        public void Dispose()
        {
            WriteTransactionsToFile();
            GC.SuppressFinalize(this);

        }

        //private int AccountNumberGenerator()
        //{
        //    return nextAccountNumber++;
        //}


        public void WithdrawMoney(decimal money)
        {
            if ((this.balance - money) >= 0)
            {
                this.balance -= money;

                _transactionHistory.Enqueue(new BankTransaction(-money));
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счету");
            }
        }
        /// <summary>
        /// Метод для вывода истории транзакций.
        /// </summary>
        public void PrintHistoryTransaction()
        {
            Console.WriteLine("История транзакций: ");

            if (_transactionHistory.Count == 0)
            {
                Console.WriteLine("История транзакций пуста.");
                return;
            }

            foreach (var transaction in _transactionHistory)
            {
                Console.WriteLine(transaction);
            }


        }

        /// <summary>
        /// Пополняет сумму на счет.
        /// </summary>
        /// <param name="money">Сумма пополнения.</param>
        public void DepositMoney(decimal money)
        {
            this.balance += money;
            _transactionHistory.Enqueue(new BankTransaction(money));
        }

        public void TransferMoneyTo(BankAccountFor5Task bankAccount, decimal money)
        {
            if ((this.balance - money) >= 0)
            {
                this.balance -= money;
                bankAccount.balance += money;
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счету");
            }
        }
        #endregion

    }
}
