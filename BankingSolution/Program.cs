using System;
using BankingLibrary;

namespace BankingSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 11.1");

            var fabricAccount = new BankFactory();

            BankAccountType accountTypeCurrent = BankAccountType.Current;
            BankAccountType accountTypeSavings = BankAccountType.Savings;

            var accountId1 = fabricAccount.CreateBankAccount(accountTypeSavings);
            var accountId2 = fabricAccount.CreateBankAccount(10000, accountTypeCurrent);
            Console.WriteLine("Выводим аккаунты хэш-таблицы:");
            fabricAccount.GetBankAccount(accountId1);
            fabricAccount.GetBankAccount(accountId2);
            Console.WriteLine("Удаляем один объект из хэш-таблицы: ");
            fabricAccount.RemoveHashTable(accountId1);
            Console.WriteLine("Пробуем вывести удаленный объект: ");
            fabricAccount.GetBankAccount(accountId1);
        }
    }
}
