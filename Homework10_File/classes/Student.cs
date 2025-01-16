

namespace Homework10_File
{
    public class Student
    {
        #region Поля
        public string Name { get; set; }
        public string Group { get; set; }
        public int Absences { get; set; } 
        #endregion

        #region Конструктор
        public Student(string name, string group)
        {
            Name = name;
            Group = group;
            Absences = 0;
        }
        #endregion
    }
}
