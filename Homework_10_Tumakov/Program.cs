namespace Homework_10_Tumakov
{
    internal class Program
    {

        static void Task1()
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

        static void Task3()
        {
            Console.WriteLine("Домашнее задание 11.1\n");
            int IdBuild1 = Creator.CreateBuild(10, 12,25);
            int IdBuild2 = Creator.CreateBuild(10, 20, 3, 13);
            int IdBuild3 = Creator.CreateBuild(10, 18, 14);
            Console.WriteLine("Выводим мнформацию экземпляр до удаления: \n");
            Creator.GetBuild(IdBuild2); 
            Creator.RemoveBuild(IdBuild2);
            Console.WriteLine("Выводим информацию после удаления экземпляра: \n");
            Creator.GetBuild(IdBuild2);

        }

        static void Task5()
        {
            Console.WriteLine("\nУпражнение 12.1");
            Guid Idaccount1 = Guid.NewGuid();
            Guid Idaccount2 = Guid.NewGuid();

            var account1 = new BankAccountFor5Task(1000, BankAccountType.Current, Idaccount1);
            var account2 = new BankAccountFor5Task(1000, BankAccountType.Current, Idaccount2);

            var result = account1 == account2;

            Console.WriteLine(result); // Пример ==
            Console.WriteLine(account1); // Пример ToString()

            Console.WriteLine(Equals(account1, account2));

            var set = new HashSet<BankAccountFor5Task> { account2, account1};
            Console.WriteLine(set.Count);
        }

        static void Task6()
        {
            Console.WriteLine("\nУпражнение 12.2\n");

            RationalNumbers number1 = new RationalNumbers(10, 2);
            RationalNumbers number2 = new RationalNumbers(10, 2);

            Console.WriteLine(number1 == number2);
            Console.WriteLine(number1);

            int IntNumber = 12;
            var newNumber = (RationalNumbers)IntNumber;
            Console.WriteLine($"\nВывод значения переведенного из int:\n{newNumber}\n");

            var plusNumbers = number1 + number2;
            Console.WriteLine($"{plusNumbers}");

        }

        static void Task7()
        {
            Console.WriteLine("\nДомашнее задание 12.1 \n");
            ComplexNumber number1 = new ComplexNumber(2, 3);
            ComplexNumber number2 = new ComplexNumber(4, 6);
            Console.WriteLine("\nВывод комплексного числа:");
            Console.WriteLine(number1);
            ComplexNumber newNumber = number1 + number2;
            Console.WriteLine("\nВывод комплексного числа после сложения: ");
            Console.WriteLine(newNumber);
            newNumber = number1 * number2;
            Console.WriteLine("\nВывод комплексного числа после умножения: ");
            Console.WriteLine(newNumber);

        }

        static void Task8()
        {
            Console.WriteLine("\nДомашнее задание 12.2\n");
            Book[] books = new Book[]
        {
            new Book("1984", "George Orwell", "Secker & Warburg"),
            new Book("Brave New World", "Aldous Huxley", "Chatto & Windus"),
            new Book("Fahrenheit 451", "Ray Bradbury", "Ballantine Books")
        };

            ContainerBook container = new ContainerBook(books);

            container.SortBooks((b1, b2) => string.Compare(b1.Name, b2.Name));

            Console.WriteLine("Сортировка по названию:");
            foreach (var book in container.Books)
            {
                Console.WriteLine($"{book.Name} - {book.Author} - {book.Publishing}");
            }

            container.SortBooks((b1, b2) => string.Compare(b1.Author, b2.Author));

            Console.WriteLine("\nСортировка по автору:");
            foreach (var book in container.Books)
            {
                Console.WriteLine($"{book.Name} - {book.Author} - {book.Publishing}");
            }

            container.SortBooks((b1, b2) => string.Compare(b1.Publishing, b2.Publishing));

            Console.WriteLine("\nСортировка по издательству:");
            foreach (var book in container.Books)
            {
                Console.WriteLine($"{book.Name} - {book.Author} - {book.Publishing}");
            }
        }

        static void Main(string[] args)
        {
            Task1();
            Task3();
            Task5();
            Task6();
            Task7();
            Task8();
        }
    }
}
