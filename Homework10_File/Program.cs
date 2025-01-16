namespace Homework10_File
{
    internal class Program
    {
        
        static void Task1()
        {
            Console.WriteLine("Задача 1\n");
            string studentsFile = "students.txt";
            string eventsFile = "events.txt";

            EventManager manager = new EventManager(studentsFile, eventsFile);

            
            Console.Write("Введите название мероприятия: ");
            string eventName = Console.ReadLine();
            Console.Write("Введите дату мероприятия (в формате ГГГГ-ММ-ДД): ");
            DateTime eventDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Введите количество участников от каждой группы: ");
            int participantsPerGroup = int.Parse(Console.ReadLine());

            
            Event newEvent = new Event(eventName, eventDate);

           
            manager.SelectParticipants(newEvent, participantsPerGroup);

            
            manager.SaveEvent(newEvent);

            Console.WriteLine("Мероприятие успешно создано и сохранено!");
        }

        static void Task2()
        {
            EventTracker eventTracker = new EventTracker();

            eventTracker.AddPerson(new Person("Анна", "концерт"));
            eventTracker.AddPerson(new Person("Иван", "выход сериала"));
            eventTracker.AddPerson(new Person("Мария", "выставка"));

            Console.WriteLine("Выберите событие из списка: концерт, выход сериала, выставка.");
            Console.Write("Введите событие: ");
            string userEvent = Console.ReadLine();

            eventTracker.CheckEvent(userEvent);

            
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
    }
}
