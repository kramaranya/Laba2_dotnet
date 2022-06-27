using System.Xml.Linq;

namespace Laba2_dotnet;

public class XElementToObject
{
    public static Enterprise? Enterprise(XElement? element)
    {
        if (element is null)
            return null;

        return new Enterprise()
        {
            Id = Convert.ToInt32(element.Attribute("Id")?.Value),
            Name = element.Element("Name")?.Value,
            Income = Convert.ToInt32(element.Element("Income")?.Value),
        };
    }

    public static Employee? Employee(XElement? element)
    {
        if (element is null)
            return null;

        return new Employee()
        {
            Id = Convert.ToInt32(element.Attribute("Id")?.Value),
            Surname = element.Element("Surname")?.Value,
            Name = element.Element("Name")?.Value,
            Gender = Enum.Parse<Gender>(element.Element("Gender")?.Value ?? "Unknown"),
            BirthDate = Convert.ToDateTime(element.Element("DateOfBirth")?.Value),
            Salary = Convert.ToInt32(element.Element("Salary")?.Value),
            WorkExperience = Convert.ToInt32(element.Element("WorkExperience")?.Value),
            EnterpriseId = Convert.ToInt32(element.Element("EnterpriseId")?.Value),
        };
    }

    public static Equipment? Equipment(XElement? element)
    {
        if (element is null)
            return null;

        return new Equipment()
        {
            Id = Convert.ToInt32(element.Attribute("Id")?.Value),
            TypeOfEquipment = Enum.Parse<TypeOfEquipment>(element.
            Element("TypeOfEquipment")?.Value ?? "Unknown"),
            BrandId = Convert.ToInt32(element.Element("BrandId")?.Value),
            Price = Convert.ToInt32(element.Element("Price")?.Value),
            Power = Convert.ToInt32(element.Element("Power")?.Value),
            EnterpriseId = Convert.ToInt32(element.Element("EnterpriseId")?.Value),
        };
    }

    public static Brand? Brand(XElement? element)
    {
        if (element is null)
            return null;

        return new Brand()
        {
            Id = Convert.ToInt32(element.Attribute("Id")?.Value),
            Name = element.Element("Name")?.Value,
        };
    }

    public static EmployeeEquipmentConnection? Connection(XElement? element)
    {
        if (element is null)
            return null;

        return new EmployeeEquipmentConnection()
        {
            Id = Convert.ToInt32(element.Attribute("Id")?.Value),
            EmployeeId = Convert.ToInt32(element.Element("EmployeeId")?.Value),
            EquipmentId = Convert.ToInt32(element.Element("EquipmentId")?.Value),
        };
    }
}