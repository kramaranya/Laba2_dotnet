using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Laba2_dotnet;

public class XMLReader
{
    public static void EnterprisePrinter(XmlDocument doc, string header = "")
    {
        try
        {
            doc.Load(XmlPathes.EnterprisePath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        if (doc.DocumentElement == null)
        {
            Console.WriteLine("Fill out the file.");
            return;
        }
        
        XmlElement root = doc.DocumentElement;
        
        if (header.Length >= 1)
        {
            Console.WriteLine(header);
        }
        foreach (XmlElement? childNode in root)
        {
            string? id = childNode?.Attributes.GetNamedItem("Id")?.InnerText;
            string? name = childNode?["Name"]?.InnerText;
            string? income = childNode?["Income"]?.InnerText; 

            Console.WriteLine($"Enterpise[{id}]\tName: {name}\tIncome: {income}\n");
        }
    }
    public static void EmployeePrinter(XmlDocument doc, string header = "")
    {
        try
        {
            doc.Load(XmlPathes.EmployeePath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        if (doc.DocumentElement == null)
        {
            Console.WriteLine("Fill out the file.");
            return;
        }
        
        XmlElement root = doc.DocumentElement;

        if (header.Length >= 1)
        {
            Console.WriteLine(header);
        }
        foreach (XmlElement? childNode in root)
        {
            string? id = childNode?.Attributes.GetNamedItem("Id")?.InnerText;
            string? surname = childNode?["Surname"]?.InnerText;
            string? name = childNode?["Name"]?.InnerText;
            string? gender = childNode?["Gender"]?.InnerText;
            string? birthdate = childNode?["Birthdate"]?.InnerText;
            string? salary = childNode?["Salary"]?.InnerText;
            string? workExperience = childNode?["WorkExperience"]?.InnerText;
            string? enterpriseId = childNode?["EnterpriseId"]?.InnerText;

            Console.WriteLine($"Id: {id}\t Surname: {surname}\t Name: {name}\t Date Of Birth: {birthdate:d}\t" +
                $"Salary: {salary}\t Work Experience: {workExperience}\t Enterprise Id: {enterpriseId}\t");
        }
    }
    public static void EquipmentPrinter(XmlDocument doc, string header = "")
    {
        try
        {
            doc.Load(XmlPathes.EquipmentPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        if (doc.DocumentElement == null)
        {
            Console.WriteLine("Fill out the file.");
            return;
        }
        
        XmlElement root = doc.DocumentElement;

        if (header.Length >= 1)
        {
            Console.WriteLine(header);
        }
        foreach (XmlElement? childNode in root)
        {
            string? id = childNode?.Attributes.GetNamedItem("Id")?.InnerText;
            string? typeOfEquipment = childNode?["TypeOfEquipment"]?.InnerText;
            string? brandId = childNode?["Brand"]?.InnerText;
            string? price = childNode?["Price"]?.InnerText;
            string? power = childNode?["Power"]?.InnerText;
            string? enterpriseId = childNode?["EnterpriseId"]?.InnerText;

            Console.WriteLine($"Id: {id}\t Type: {typeOfEquipment}\t Brand: {brandId}\t Price: {price}\t Power: {power}\t" +
            $"Enterprise Id: {enterpriseId}\t");
        }
    }
    public static void BrandPrinter(XmlDocument doc, string header = "")
    {
        try
        {
            doc.Load(XmlPathes.BrandPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        if (doc.DocumentElement == null)
        {
            Console.WriteLine("Fill out the file.");
            return;
        }
        
        XmlElement root = doc.DocumentElement;

        if (header.Length >= 1)
        {
            Console.WriteLine(header);
        }
        foreach (XmlElement? childNode in root)
        {
            string? id = childNode?.Attributes.GetNamedItem("Id")?.InnerText;
            string? name = childNode?["Name"]?.InnerText;

            Console.WriteLine($"Id: {id}\t Name: {name}\t");
        }
    }
    public static void ConnectionPrinter(XmlDocument doc, string header = "")
    {
        try
        {
            doc.Load(XmlPathes.ConnectionPath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        if (doc.DocumentElement == null)
        {
            Console.WriteLine("Fill out the file.");
            return;
        }
        
        XmlElement root = doc.DocumentElement;

        if (header.Length >= 1)
        {
            Console.WriteLine(header);
        }
        foreach (XmlElement? childNode in root)
        {
            string? id = childNode?.Attributes.GetNamedItem("Id")?.InnerText;
            string? employeeId = childNode?["EmployeeId"]?.InnerText;
            string? equipmentId = childNode?["EquipmentId"]?.InnerText;

            Console.WriteLine($"Id: {id}\t Employee: {employeeId}\t Equipment: {equipmentId}\t");
        }
    }
}
