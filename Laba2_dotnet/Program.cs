namespace Laba2_dotnet;
class Program
{
    public static void Main(string[] args)
    {
        var menu = new Menu();
        
        int choose = -1;
        do
        {
            try
            {
                choose = menu.HowToEnterTheData();
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter correct data!");
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            if (choose == -1)
                choose = menu.HowToEnterTheData();
        } while (choose == 1);
        PrintQueries.PrintAllQueries();
    }
}