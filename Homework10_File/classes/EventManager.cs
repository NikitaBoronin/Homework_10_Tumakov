

namespace Homework10_File
{
    public class EventManager
    {
        #region Поля
        private List<Student> students;
        private string studentsFile;
        private string eventsFile;
        #endregion
        #region Конструктор
        public EventManager(string studentsFilePath, string eventsFilePath)
        {
            studentsFile = studentsFilePath;
            eventsFile = eventsFilePath;
            students = new List<Student>();
            LoadStudents();
        }
        #endregion
        #region Методы
        public void LoadStudents()
        {
            if (!File.Exists(studentsFile))
            {
                Console.WriteLine("Файл со студентами отсутствует. Создайте файл students.txt и заполните его.");
                Environment.Exit(1);
            }

            foreach (var line in File.ReadAllLines(studentsFile))
            {
                var parts = line.Split(",");
                if (parts.Length == 2)
                {
                    students.Add(new Student(parts[0].Trim(), parts[1].Trim()));
                }
            }
        }

        public void SelectParticipants(Event newEvent, int participantsPerGroup)
        {
            var groups = students.GroupBy(s => s.Group);

            if (groups.Count() < 2)
            {
                Console.WriteLine("Недостаточно групп для проведения мероприятия (необходимо минимум две).");
                Environment.Exit(1);
            }

            foreach (var group in groups)
            {
                var willingStudents = group.Where(s => s.Absences == 0).ToList();
                var otherStudents = group.Where(s => s.Absences > 0).OrderByDescending(s => s.Absences).ToList();

                var selectedStudents = willingStudents.Take(participantsPerGroup).ToList();

                if (selectedStudents.Count < participantsPerGroup)
                {
                    selectedStudents.AddRange(otherStudents.Take(participantsPerGroup - selectedStudents.Count));
                }

                foreach (var student in selectedStudents)
                {
                    newEvent.Participants.Add(student);
                    student.Absences = 0; 
                }

                foreach (var student in group.Except(selectedStudents))
                {
                    student.Absences++;
                }
            }
        }

        public void SaveEvent(Event newEvent)
        {
            using (var writer = new StreamWriter(eventsFile, true))
            {
                writer.WriteLine($"Дата: {newEvent.Date:yyyy-MM-dd}, Мероприятие: {newEvent.Name}");
                foreach (var participant in newEvent.Participants)
                {
                    writer.WriteLine($"  {participant.Name} ({participant.Group})");
                }
                writer.WriteLine();
            }
        }

        public List<Student> GetStudents() => students;
        #endregion
    }
}
