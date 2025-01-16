

namespace Homework_10_Tumakov
{
    internal class Book
    {
        #region Поля
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publishing { get; set; }
        #endregion

        #region Конструктор

        public Book(string name, string author, string publishing)
        {
            Name = name;
            Author = author;
            Publishing = publishing;
        }
        #endregion
    }

}
