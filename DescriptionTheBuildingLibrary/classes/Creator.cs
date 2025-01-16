using System.Collections;

namespace DescriptionTheBuildingLibrary
{
    public class Creator
    {
        #region Поле
        private static Hashtable Hashtable = new Hashtable();
        #endregion


        #region Конструктор
        private Creator() { }
        #endregion

        #region Методы
        /// <summary>
        /// Метод, который создает и доавляет экземпляр класса DescriptionTheBuilding в хэш-таблицу
        /// </summary>
        /// <param name="floor"></param>
        /// <param name="height"></param>
        /// <returns>Id здания экземпляра класса DescriptionTheBuilding</returns>
        public static int CreateBuild(int floor, int height)
        {
            var building = new DescriptionTheBuilding(floor, height);
            Hashtable[building.IdBuilding] = building;
            return building.IdBuilding;
        }
        /// <summary>
        /// Метод, который создает и доавляет экземпляр класса DescriptionTheBuilding в хэш-таблицу
        /// </summary>
        /// <param name="floor"></param>
        /// <param name="numberOfApartments"></param>
        /// <param name="numberOfEntrances"></param>
        /// <param name="height"></param>
        /// <returns>Id здания экземпляра класса DescriptionTheBuilding</returns>
        public static int CreateBuild(int floor, int numberOfApartments, int numberOfEntrances, int height)
        {
            var building = new DescriptionTheBuilding(floor, numberOfApartments, numberOfEntrances, height);
            Hashtable[building.IdBuilding] = building;
            return building.IdBuilding;
        }
        /// <summary>
        /// Метод, который создает и доавляет экземпляр класса DescriptionTheBuilding в хэш-таблицу
        /// </summary>
        /// <param name="floor"></param>
        /// <param name="numberOfApartments"></param>
        /// <param name="height"></param>
        /// <returns>Id здания экземпляра класса DescriptionTheBuilding</returns>
        public static int CreateBuild(int floor, int numberOfApartments, int height)
        {
            var building = new DescriptionTheBuilding(floor, numberOfApartments, height);
            Hashtable[building.IdBuilding] = building;
            return building.IdBuilding;
        }
        /// <summary>
        /// Метод, который выводит информацию экземпляра класса DescriptionTheBuilding
        /// </summary>
        /// <param name="building">Экземпляр по которому нужно вывести информацию</param>
        public static void GetBuild(int IdBuild)
        {
            if (Hashtable.ContainsKey(IdBuild))
            {
                Console.WriteLine("Вывод объекта: ");
                var build = (DescriptionTheBuilding)Hashtable[IdBuild];
                Console.WriteLine(build.ToString());
            }
            else
            {
                Console.WriteLine("Объект отсутсвует!");
            }
        }
        /// <summary>
        /// Метод, который удаляет экземпляр класса из хэш-таблицы
        /// </summary>
        /// <param name="Building">Экземпляр который нужно удалить</param>
        public static void RemoveBuild(int IdBuild)
        {

            Hashtable.Remove(IdBuild);
            Console.WriteLine("Объект успешно удален!\n");
        }

        #endregion

    }
}
