using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Laba2_dotnet;
public class ManualXMLWriter
{
    public static void ManualEnterpriseFill(string Enterprise_PATH)
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };
        using (XmlWriter writer = XmlWriter.Create(Enterprise_PATH, settings))
        {

            writer.WriteStartElement("Enterprises");
            bool correct;
            do
            {
                writer.WriteStartElement("Enterprise");

                Console.WriteLine("\nEnter the enterprise Id:");
                int id;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out id);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);
                Console.WriteLine("Enter the name of the enterprise:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the income of the enterprise:");
                string income = Console.ReadLine();

                writer.WriteAttributeString("Id", id.ToString());
                writer.WriteElementString("Name", name);
                writer.WriteElementString("Income", income);

                writer.WriteEndElement();
                Console.WriteLine("Press Enter to enter another Enterprise.");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
            writer.WriteEndElement();
        }
    }
    public static void ManualEmployeeFill(string Employee_PATH)
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };
        using (XmlWriter writer = XmlWriter.Create(Employee_PATH, settings))
        {

            writer.WriteStartElement("Employees");
            bool correct;
            do
            {
                writer.WriteStartElement("Employee");

                Console.WriteLine("\nEnter the employee Id:");
                int id;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out id);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);
                Console.WriteLine("Enter the surname of the employee:");
                string surname = Console.ReadLine();
                Console.WriteLine("Enter the surname of the employee:");
                string name = Console.ReadLine();
                Console.WriteLine("Genders: ");
                var genders = Enum.GetValues(typeof(Gender));
                int genderid;
                for (var i = 0; i < genders.Length; i++)
                {
                    Console.WriteLine($"{i} {genders.GetValue(i)}");
                }
                Console.Write("\n\tEnter gender Id: ");
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out genderid);
                    if (!correct || genderid < 0 || genderid >= genders.Length)
                        Console.WriteLine("Enter correct data!");
                } while (!correct || genderid < 0 || genderid >= genders.Length);
                string gender = ((Gender)genderid).ToString();
                DateTime dateofbirth;
                Console.WriteLine("Enter the date of birth: (dd.mm.yyyy)");
                do
                {
                    correct = DateTime.TryParse(Console.ReadLine(), out dateofbirth);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);

                Console.WriteLine("\nEnter the employee salary:");
                int salary;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out salary);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);

                Console.WriteLine("\nEnter the employee work experience:");
                int workexperience;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out workexperience);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);

                Console.WriteLine("\nEnter the employee enterprise id:");
                int enterpriseid;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out enterpriseid);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);

                writer.WriteAttributeString("Id", id.ToString());
                writer.WriteElementString("Surname", surname);
                writer.WriteElementString("Name", name);
                writer.WriteElementString("Gender", gender);
                writer.WriteElementString("DateOfBirth", dateofbirth.ToString());
                writer.WriteElementString("Salary", salary.ToString());
                writer.WriteElementString("WorkExperience", workexperience.ToString());
                writer.WriteElementString("EnterpriseId", enterpriseid.ToString());

                writer.WriteEndElement();
                Console.WriteLine("Press Enter to enter another Employee.");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
            writer.WriteEndElement();
        }
    }
    public static void ManualEquipmentFill(string Equipment_PATH)
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };
        using (XmlWriter writer = XmlWriter.Create(Equipment_PATH, settings))
        {

            writer.WriteStartElement("Equipments");
            bool correct;
            do
            {
                writer.WriteStartElement("Equipment");

                Console.WriteLine("\nEnter the equipment Id:");
                int id;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out id);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);

                Console.WriteLine("Type Of Equipment: ");
                var types = Enum.GetValues(typeof(TypeOfEquipment));
                int typeid;
                for (var i = 0; i < types.Length; i++)
                {
                    Console.WriteLine($"{i} {types.GetValue(i)}");
                }
                Console.Write("\n\tEnter type Id: ");
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out typeid);
                    if (!correct || typeid < 0 || typeid >= types.Length)
                        Console.WriteLine("Enter correct data!");
                } while (!correct || typeid < 0 || typeid >= types.Length);
                string type = ((TypeOfEquipment)typeid).ToString();

                Console.WriteLine("\nEnter the equipment brand id:");
                int brandid;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out brandid);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);

                Console.WriteLine("\nEnter the equipment price:");
                int price;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out price);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);
                Console.WriteLine("\nEnter the equipment brand id:");
                int power;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out power);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);
                Console.WriteLine("\nEnter the equipment enterprise id:");
                int enterpriseid;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out enterpriseid);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);


                writer.WriteAttributeString("Id", id.ToString());
                writer.WriteElementString("TypeOfEquipment", type.ToString());
                writer.WriteElementString("BrandId", brandid.ToString());
                writer.WriteElementString("Price", price.ToString());
                writer.WriteElementString("Power", power.ToString());
                writer.WriteElementString("EnterpriseId", enterpriseid.ToString());

                writer.WriteEndElement();
                Console.WriteLine("Press Enter to enter another Equipment.");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
            writer.WriteEndElement();
        }
    }
    public static void ManualBrandFill(string Brand_PATH)
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };
        using (XmlWriter writer = XmlWriter.Create(Brand_PATH, settings))
        {

            writer.WriteStartElement("Brands");
            bool correct;
            do
            {
                writer.WriteStartElement("Brand");

                Console.WriteLine("\nEnter the Brand Id:");
                int id;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out id);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);
                Console.WriteLine("Enter the name of the brand:");
                string name = Console.ReadLine();
                
                writer.WriteAttributeString("Id", id.ToString());
                writer.WriteElementString("Name", name);

                writer.WriteEndElement();
                Console.WriteLine("Press Enter to enter another Brand.");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
            writer.WriteEndElement();
        }
    }
    public static void ManualConnectionFill(string Connection_PATH)
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };
        using (XmlWriter writer = XmlWriter.Create(Connection_PATH, settings))
        {

            writer.WriteStartElement("Connections");
            bool correct;
            do
            {
                writer.WriteStartElement("Connection");

                Console.WriteLine("\nEnter the Connection Id:");
                int id;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out id);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);
                Console.WriteLine("\nEnter the Employee Id:");
                int employeeid;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out employeeid);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);
                Console.WriteLine("\nEnter the Equipment Id:");
                int equipmentid;
                do
                {
                    correct = int.TryParse(Console.ReadLine(), out equipmentid);
                    if (!correct)
                        Console.WriteLine("Enter correct data!");
                } while (!correct);
                writer.WriteAttributeString("Id", id.ToString());
                writer.WriteElementString("EmployeeId", employeeid.ToString());
                writer.WriteElementString("EquipmentId", equipmentid.ToString());

                writer.WriteEndElement();
                Console.WriteLine("Press Enter to enter another Connection.");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
            writer.WriteEndElement();
        }
    }
}
