using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml;

namespace Laba2_dotnet;

public class AutoXMLWriter
{
    public static void EnterpiseFill(string Enterprise_PATH) { 

        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };

        using (XmlWriter writer = XmlWriter.Create(Enterprise_PATH, settings))
        {
            writer.WriteStartElement("Enterprises");
            foreach (var item in Data.EnterprisesList)
            {
                writer.WriteStartElement("Enterprise");
                writer.WriteAttributeString("Id", item.Id.ToString());
                writer.WriteElementString("Name", item.Name);
                writer.WriteElementString("Income", item.Income.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
    public static void EquipmentFill(string Equipment_PATH)
    {

        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };

        using (XmlWriter writer = XmlWriter.Create(Equipment_PATH, settings))
        {
            writer.WriteStartElement("Equipments");
            foreach (var item in Data.EquipmentList)
            {
                writer.WriteStartElement("Equipment");
                writer.WriteAttributeString("Id", item.Id.ToString());
                writer.WriteElementString("TypeOfEquipment", item.TypeOfEquipment.ToString());
                writer.WriteElementString("BrandId", item.BrandId.ToString());
                writer.WriteElementString("Price", item.Price.ToString());
                writer.WriteElementString("Power", item.Power.ToString());
                writer.WriteElementString("EnterpriseId", item.EnterpriseId.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
    public static void EmployeeFill(string Employee_PATH)
    {

        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };

        using (XmlWriter writer = XmlWriter.Create(Employee_PATH, settings))
        {
            writer.WriteStartElement("Employees");
            foreach (var item in Data.EmployeesList)
            {
                writer.WriteStartElement("Employee");
                writer.WriteAttributeString("Id", item.Id.ToString());
                writer.WriteElementString("Surname", item.Surname);
                writer.WriteElementString("Name", item.Name);
                writer.WriteElementString("Gender", item.Gender.ToString());
                writer.WriteElementString("DateOfBirth", item.BirthDate.ToString());
                writer.WriteElementString("Salary", item.Salary.ToString());
                writer.WriteElementString("WorkExperience", item.WorkExperience.ToString());
                writer.WriteElementString("EnterpriseId", item.EnterpriseId.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
    public static void BrandFill(string Brand_PATH)
    {

        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };

        using (XmlWriter writer = XmlWriter.Create(Brand_PATH, settings))
        {
            writer.WriteStartElement("Brands");
            foreach (var item in Data.BrandsList)
            {
                writer.WriteStartElement("Brand");
                writer.WriteAttributeString("Id", item.Id.ToString());
                writer.WriteElementString("Name", item.Name);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
    public static void EmployeeEquipmentConnectionFill(string Connection_PATH)
    {

        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true
        };

        using (XmlWriter writer = XmlWriter.Create(Connection_PATH, settings))
        {
            writer.WriteStartElement("Connections");
            foreach (var item in Data.Connections)
            {
                writer.WriteStartElement("Connection");
                writer.WriteAttributeString("Id", item.Id.ToString());
                writer.WriteElementString("EmployeeId", item.EmployeeId.ToString());
                writer.WriteElementString("EquipmentId", item.EquipmentId.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}
