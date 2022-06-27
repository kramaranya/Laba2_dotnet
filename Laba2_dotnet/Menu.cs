using System.Xml;

namespace Laba2_dotnet;

public class Menu
{
    private static int _choose;
    private static int _tryAgain;
    private static bool _dataIsCorrect;
    
    public int HowToEnterTheData()
    {
        Console.WriteLine("How to enter the data?\n");
        do
        {
            Console.WriteLine("1 - Manually\n2 - Auto\n");
            _dataIsCorrect = Int32.TryParse(Console.ReadLine(), out _choose) && _choose is >= 1 and <= 2;
            
            if (_dataIsCorrect) continue;
            
            Console.WriteLine("\nEnter correct value.\n");
        } while (!_dataIsCorrect);

        switch (_choose)
        {
            case 1:
                ManualXMLWriter.ManualEnterpriseFill(XmlPathes.EnterprisePath);
                ManualXMLWriter.ManualEmployeeFill(XmlPathes.EmployeePath);
                ManualXMLWriter.ManualEquipmentFill(XmlPathes.EquipmentPath);
                ManualXMLWriter.ManualBrandFill(XmlPathes.BrandPath);
                ManualXMLWriter.ManualConnectionFill(XmlPathes.ConnectionPath);
                break;
            case 2:
                AutoXMLWriter.EnterpiseFill(XmlPathes.EnterprisePath);
                AutoXMLWriter.EmployeeFill(XmlPathes.EmployeePath);
                AutoXMLWriter.EquipmentFill(XmlPathes.EquipmentPath);
                AutoXMLWriter.BrandFill(XmlPathes.BrandPath);
                AutoXMLWriter.EmployeeEquipmentConnectionFill(XmlPathes.ConnectionPath);
                break;
        }
        
        XmlDocument doc = new XmlDocument();

        XMLReader.EnterprisePrinter(doc);
        XMLReader.EmployeePrinter(doc);
        XMLReader.EquipmentPrinter(doc);
        XMLReader.BrandPrinter(doc);
        XMLReader.ConnectionPrinter(doc);
        
        PrintQueries.PrintAllQueries();
        return TryAgain();
    }
    private static int TryAgain()
    {
        do
        {
            Console.WriteLine("1 - Try again\n2 - Exit\n");
            _dataIsCorrect = Int32.TryParse(Console.ReadLine(), out _tryAgain) && _tryAgain is >= 1 and <= 2;
            
            if (_dataIsCorrect) continue;

            Console.WriteLine("\nEnter correct value.\n\n");
        } while (!_dataIsCorrect);
        
        Console.WriteLine();
        return _tryAgain;
    }
}