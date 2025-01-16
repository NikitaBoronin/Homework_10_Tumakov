

namespace Homework10_File
{
    public class EventTracker
    {
        #region Поле
        private List<Person> _people;
        #endregion

        #region Конструктор
        public EventTracker()
        {
            _people = new List<Person>();
        }
        #endregion

        #region Методы
        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

        
        public void CheckEvent(string eventName)
        {
            bool eventFound = false;

            foreach (var person in _people)
            {
                if (person.Hobby.Equals(eventName, StringComparison.OrdinalIgnoreCase))
                {
                    person.ReactToEvent(eventName);
                    eventFound = true;
                }
            }

            if (!eventFound)
            {
                Console.WriteLine($"Никто из списка не заинтересован в событии \"{eventName}\".");
            }
        }
        #endregion
    }
}
