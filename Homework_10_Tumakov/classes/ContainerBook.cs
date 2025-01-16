

namespace Homework_10_Tumakov
{
    internal class ContainerBook
    {
        #region Поле
        public Book[] Books { get; set; }
        #endregion

        #region Конструктор
        public ContainerBook(Book[] books)
        {
            Books = books;
        }
        #endregion

        #region Делегат
        public delegate int CompareBooks(Book b1, Book b2);
        #endregion

        #region Метод 
        public void SortBooks(CompareBooks compare)
        {
            Array.Sort(Books, (b1, b2) => compare(b1, b2));
        }
        #endregion
    }
}
