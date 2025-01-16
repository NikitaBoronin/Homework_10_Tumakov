

namespace Homework_10_Tumakov
{
    internal class DescriptionTheBuilding
    {
        #region Поля
        private static int _buildingNumberId = 1;
        private int _idBuilding;
        private double _height;
        private int _floor;
        private int _numberOfApartments;
        private int _numberOfEntrances;
        #endregion

        #region Свойства
        public int IdBuilding => _idBuilding;
        public double Height { get => _height; private set => _height = value; }
        public int Floor { get => _floor; private set => _floor = value; }
        public int NumberOfApartments { get => _numberOfApartments; private set => _numberOfApartments = value; }
        public int NumberOfEntrances { get => _numberOfEntrances; private set => _numberOfEntrances = value; }
        #endregion

        #region Методы
        private void GenerateId()
        {
            _idBuilding = _buildingNumberId++;
        }

        public void SetValues()
        {
            Console.WriteLine("Введите высоту здания (в метрах):");
            while (!Double.TryParse(Console.ReadLine(), out _height) || _height <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректное положительное целое число для высоты:");
            }

            Console.WriteLine("Введите количество этажей:");
            while (!int.TryParse(Console.ReadLine(), out _floor) || _floor <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректное положительное целое число для этажей:");
            }

            Console.WriteLine("Введите количество квартир:");
            while (!int.TryParse(Console.ReadLine(), out _numberOfApartments) || _numberOfApartments <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректное положительное целое число для квартир:");
            }

            Console.WriteLine("Введите количество подъездов:");
            while (!int.TryParse(Console.ReadLine(), out _numberOfEntrances) || _numberOfEntrances <= 0)
            {
                Console.WriteLine("Ошибка! Введите корректное положительное целое число для подъездов:");
            }

            if (_height / _floor < 2)
            {
                Console.WriteLine("Предупреждение: высота этажа слишком мала!");
            }
        }

        public override string ToString()
        {
            return $"ID здания: {_idBuilding}\nВысота здания: {_height} м\nКоличество этажей: {_floor}\nКоличество квартир: {_numberOfApartments}\nКоличество подъездов: {_numberOfEntrances}\n";
        }

        public void PrintValues()
        {
            Console.WriteLine($"ID здания: {_idBuilding}");
            Console.WriteLine($"Высота здания: {_height} м");
            Console.WriteLine($"Количество этажей: {_floor}");
            Console.WriteLine($"Количество квартир: {_numberOfApartments}");
            Console.WriteLine($"Количество подъездов: {_numberOfEntrances}");
        }

        public double CalculateFloorHeight()
        {
            if (_floor == 0) throw new InvalidOperationException($"{nameof(CalculateFloorHeight)}: Количество этажей не может быть нулевым.");
            return (double)_height / _floor;
        }

        public int CalculateApartmentsPerEntrance()
        {
            if (_numberOfEntrances == 0) throw new InvalidOperationException($"{nameof(CalculateApartmentsPerEntrance)}: Количество подъездов не может быть нулевым.");
            return _numberOfApartments / _numberOfEntrances;
        }

        public int CalculateApartmentsPerFloor()
        {
            if (_floor == 0) throw new InvalidOperationException($"{nameof(CalculateApartmentsPerFloor)}: Количество этажей не может быть нулевым.");
            return _numberOfApartments / _floor;
        }
        #endregion

        #region Конструктор
        
        internal DescriptionTheBuilding(int floor, int numberOfApartments, int numberOfEntrances, int height)
        {
            GenerateId();
            Floor = floor;
            NumberOfApartments = numberOfApartments;
            NumberOfEntrances = numberOfEntrances;
            Height = height;
        }

        internal DescriptionTheBuilding(int floor, int height)
        {
            GenerateId();
            Floor = floor;
            Height = height;
        }

        internal DescriptionTheBuilding(int floor, int numberOfApartments, int height)
        {
            GenerateId();
            Floor = floor;
            Height = height;
            NumberOfApartments = numberOfApartments;
        }

        internal DescriptionTheBuilding()
        {
            GenerateId();
        }
        #endregion
    }
}
