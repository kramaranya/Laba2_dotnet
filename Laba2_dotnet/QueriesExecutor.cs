using System;
using System.Collections.Generic;
using System.Linq;
using Laba2_dotnet;
using System.Xml.Linq;
public class QueriesExecutor
{
    public IEnumerable<EquipmentAndCompany> GetAmountOfEquipmentsInCompany
        (IEnumerable<XElement> equipments)
    {
        return from equipment in equipments
               group equipment by (int)equipment.Element("EnterpriseId")
               into enterprise
               select new EquipmentAndCompany()
               {
                   EnterpriseID = enterprise.Key,
                   AmountOfEquipment = enterprise.Count(),
               };
    }

    public double GetAverageIncome(IEnumerable<XElement> enterprises)
    {
        return enterprises.Average(enterprise => (int)enterprise.Element("Income"));
    }

    public IEnumerable<HighIncomeCompanyAndEmployee> GetHighIncomeCompanyAndEmployees
        (IEnumerable<XElement> enterprises, IEnumerable<XElement> employees)
    {
        return enterprises.Where(enterprise => (int)enterprise.Element("Income") >=
            enterprises.Average(enterprise => (int)enterprise.Element("Income")))
            .Join(employees, enterprise => (int)enterprise.Attribute("Id"),
            employee => (int)employee.Element("EnterpriseId"),
            (enterprise, employee) => new HighIncomeCompanyAndEmployee()
            {
                Employee = XElementToObject.Employee(employee),
                Enterprisename = (string)enterprise.Element("Name"),
                Income = (int)enterprise.Element("Income")
            });
    }

    public IEnumerable<NumberOfEquipmentPerEmployee> GetNumberOfEquipmentPerEmployees
      (IEnumerable<XElement> connections, IEnumerable<XElement> employees)
    {
        return from employee in employees
               join equipment in connections on (int)employee.Attribute("Id") equals (int)equipment.Element("EmployeeId")
               into amount
               where amount.Count() > 1
               select new NumberOfEquipmentPerEmployee
               {
                   EmployeeId = (int)employee.Attribute("Id"),
                   EmployeeName = (string)employee.Element("Name"),
                   EmployeeSurname = (string)employee.Element("Surname"),
                   AmountOfEquipment = amount.Count(),
               };
    }

    public IEnumerable<Employee> GetSortedEmployeeBornInSomeMonth
        (IEnumerable<XElement> employees, int month = 01)
    {
        return from employee in employees
               where Convert.ToDateTime((string)employee.Element("DateOfBirth")).Month == month
               orderby Convert.ToDateTime((string)employee.Element("DateOfBirth"))
               select XElementToObject.Employee(employee);
    }

    public Employee? GetYoungestEmployee(IEnumerable<XElement> employees)
    {
        return XElementToObject.Employee(employees
            .MinBy(daysfrobirthdate => DateTime.Today - Convert.
            ToDateTime((string)daysfrobirthdate.Element("DateOfBirth"))));
    }

    public IEnumerable<AmountOfEquipmentOnBrand> GetAmountOfEquipmentOnBrand
      (IEnumerable<XElement> brands, IEnumerable<XElement> equipments)
    {
        return from equipment in equipments
               join brand in brands
               on (int)equipment.Element("BrandId") equals (int)brand.Attribute("Id")
               group equipment by (int)equipment.Element("BrandId")
               into table
               select new AmountOfEquipmentOnBrand()
               {
                   EnterpriseId = table.Key,
                   AmountOfEquipment = table.Count(),
               };
    }

    public IEnumerable<EquipmentAllowedForEmployee> GetEquipmentAllowedForEmployee
        (IEnumerable<XElement> equipments, IEnumerable<XElement> employees)
    {
        return equipments.GroupJoin(employees,
            equipment => (int)equipment.Element("EnterpriseId"), employee => (int)employee.Element("EnterpriseId"),
            (equipment, employees) => new EquipmentAllowedForEmployee()
            {
                EnterpriseId = (int)equipment.Element("EnterpriseId"),
                Equipment = XElementToObject.Equipment(equipment),
                EmployeesAllowedXElements = employees
            });
    }

    public IEnumerable<EquipmentAndEmployee> GetEquipmentAndAmountOfEmployees(IEnumerable<XElement> equipments,
       IEnumerable<XElement> connections, IEnumerable<XElement> brands)
    {
        return from equipment in equipments
               join brand in brands on (int)equipment.Element("BrandId") equals (int)brand.Attribute("Id")
               join employee in connections on (int)equipment.Attribute("Id") equals (int)employee.Element("EmployeeId")
               into amount
               select new EquipmentAndEmployee()
               {
                   EquipmentId = (int)equipment.Attribute("Id"),
                   TypeOfEquipmentString = (string)equipment.Element("TypeOfEquipment"),
                   BrandName = (string)brand.Element("Name"),
                   AmountOfEmployees = amount.Count(),
               };
    }

    public IEnumerable<AllEquipmentInCompany> GetAllEquipmentInCompanies(IEnumerable<XElement> equipments,
        IEnumerable<XElement> enterprises, IEnumerable<XElement> brands)
    {
        return from brand in brands
               join equipment in equipments on (int)brand.Attribute("Id")
               equals (int)equipment.Element("BrandId")
               join enterprise in enterprises on (int)equipment.Element("EnterpriseId")
               equals (int)enterprise.Attribute("Id")
               orderby (string)enterprise.Element("Name"), (string)brand.Element("Name"),
               (string)equipment.Element("TypeOfEquipment")
               select new AllEquipmentInCompany
               {
                   BrandName = (string)brand.Element("Name"),
                   EnterpriseName = (string)enterprise.Element("Name"),
                   TypeOfEquipmentString = (string)equipment.Element("TypeOfEquipment")
               };
    }

    public IEnumerable<Employee> GetHighPaidMaleEmployee(IEnumerable<XElement> employees)
    {
        return employees.Where(employee => (string)employee.Element("Gender") == "Male" 
            && (int)employee.Element("WorkExperience") >= employees.Average(employee => 
            (int)employee.Element("WorkExperience"))).Select(XElementToObject.Employee);
    }

    public IEnumerable<Employee> GetSortedEmployeeBornInSomeYear
        (IEnumerable<XElement> employees, int year = 2002)
    {
        return employees.Where(employee => Convert.ToDateTime((string)employee.Element("DateOfBirth")).Year == year)
            .OrderBy(surname => (string)surname.Element("Surname"))
            .Select(XElementToObject.Employee);
    }

    public IEnumerable<UseOfEquipment> GetUseOfEquipment
      (IEnumerable<XElement> connections, IEnumerable<XElement> equipments, IEnumerable<XElement> brands)
    {
        return from equipment in equipments
               join connection in connections on (int)equipment.Attribute("Id") equals (int)connection.Element("EquipmentId")
               into equipgroup
               join brand in brands on (int)equipment.Element("BrandId") equals (int)brand.Attribute("Id")
               from item in equipgroup.DefaultIfEmpty()
               select new UseOfEquipment()
               {
                   EquipmentId = item == null ? 0 : (int)item.Element("EquipmentId"),
                   PriceOfEquipment = item == null ? 0 : (int)equipment.Element("Price"),
                   BrandName = item == null ? "Nothing" : (string)brand.Element("Name"),
                   ConnectionId = item == null ? 0 : (int)item.Attribute("Id")
               };
    }

    public IEnumerable<Equipment> GetLaptopsAndComputers(IEnumerable<XElement> equipment)
    {
        return equipment.Where(equipment => (string)equipment.Element("TypeOfEquipment") == "Laptop")
            .Concat(equipment.Where(equipment => (string)equipment.Element("TypeOfEquipment") == "Computer"))
            .OrderBy(equipment => (int)equipment.Element("Price"))
            .Select(XElementToObject.Equipment);
    }
}