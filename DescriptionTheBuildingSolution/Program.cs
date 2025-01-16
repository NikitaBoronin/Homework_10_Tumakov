using DescriptionTheBuildingLibrary;

namespace DescriptionTheBuildingSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int IdBuild1 = Creator.CreateBuild(10, 12, 25);
            int IdBuild2 = Creator.CreateBuild(10, 20, 3, 13);
            int IdBuild3 = Creator.CreateBuild(10, 18, 14);
            Console.WriteLine("Выводим мнформацию экземпляр до удаления: \n");
            Creator.GetBuild(IdBuild2); 
            Creator.RemoveBuild(IdBuild2);
            Console.WriteLine("Выводим информацию после удаления экземпляра: \n");
            Creator.GetBuild(IdBuild2);
        }
    }
}
