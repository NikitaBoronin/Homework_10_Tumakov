

namespace Homework10_File
{
    public class Event
    {
        #region Поля
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Student> Participants { get; set; }
        #endregion
        #region Конструктор
        public Event(string name, DateTime date)
        {
            Name = name;
            Date = date;
            Participants = new List<Student>();
        }
        #endregion
    }
}
