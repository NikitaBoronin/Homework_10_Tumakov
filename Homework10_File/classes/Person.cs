
namespace Homework10_File
{
    public class Person
    {
        #region Поля
        public string Name { get; set; }
        public string Hobby { get; set; }
        #endregion

        #region Конструктор
        public Person(string name, string hobby)
        {
            Name = name;
            Hobby = hobby;
        }
        #endregion

        #region Метод
        public void ReactToEvent(string eventName)
        {
            Console.WriteLine($"{Name}: Ура! Я ждал(а) событие \"{eventName}\"!");
        }
        #endregion
    }
}
