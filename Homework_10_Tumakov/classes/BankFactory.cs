﻿
using System.Collections;



namespace Homework_10_Tumakov
{
    internal class BankFactory
    { 
        #region Поля
        private Guid Id;
        private Hashtable Hashtable = new Hashtable();
        #endregion

        #region Методы
        public Guid CreateBankAccount(decimal balance)
        {
            Id = Guid.NewGuid();
            var account = new BankAccount(balance, Id);
            Hashtable[account.GetId()] = account;
            return Id;
        }

        public Guid CreateBankAccount(BankAccountType bankType )
        {
            Id = Guid.NewGuid();
            var account = new BankAccount(bankType, Id);
            Hashtable[account.GetId()] = account;
            return Id;
        }

        public Guid CreateBankAccount(decimal balance, BankAccountType bankType)
        {
            Id = Guid.NewGuid();
            var account = new BankAccount(balance, bankType, Id);
            Hashtable[account.GetId()] = account;
            return Id;
        }

        public void GetBankAccount(Guid accountId)
        {
            Console.WriteLine("Вывод объекта: ");
            Console.WriteLine(Hashtable[accountId]);
        }

        public void RemoveHashTable(Guid Id)
        {
            Hashtable.Remove(Id);
            Console.WriteLine("Объект успешно удален из таблицы!");
        }

        #endregion


    }
}
