using System;
using System.Linq;
using System.Xml.Linq;

using Laba2_dotnet;
public class PrintQueries
{
    public static void PrintAllQueries()
    {
        QueriesExecutor queriesExecutor = new QueriesExecutor();
        
        XDocument xEmployees = XDocument.Load(XmlPathes.EmployeePath);
        XDocument xEnterprises = XDocument.Load(XmlPathes.EnterprisePath);
        XDocument xEquipment = XDocument.Load(XmlPathes.EquipmentPath);
        XDocument xBrands = XDocument.Load(XmlPathes.BrandPath);
        XDocument xConnections = XDocument.Load(XmlPathes.ConnectionPath);
        
        var employees = xEmployees.Descendants("Employee");
        var enterprises = xEnterprises.Descendants("Enterprise");
        var equipment = xEquipment.Descendants("Equipment");
        var brands = xBrands.Descendants("Brand");
        var connections = xConnections.Descendants("Connection");
        

        Console.WriteLine("\nHigh Paid Male Employee:\n");
        var highPaidMaleEmployee = queriesExecutor.GetHighPaidMaleEmployee(employees);
        foreach (var item in highPaidMaleEmployee)
        {
            Console.WriteLine(item);
        }
        

        Console.WriteLine("\nAmount Of Equipment In Each Company\n");
        var amountOfEquipment = queriesExecutor.GetAmountOfEquipmentsInCompany(equipment);
        foreach (var item in amountOfEquipment)
        {
            Console.WriteLine($"Enterprise: {item.EnterpriseID}  Amount of equipment: {item.AmountOfEquipment}");
        }


        Console.WriteLine("\n Sorted Employees Which Were Born In Some Year\n");
        var employeesBirthYearOrderBySurname = queriesExecutor.GetSortedEmployeeBornInSomeYear
            (employees, 2003);
        foreach (var item in employeesBirthYearOrderBySurname)
        {
            Console.WriteLine(item);
        }
        

        Console.WriteLine("\nAll Equipment In Companies\n");
        var brandWithEquipment = queriesExecutor.GetAllEquipmentInCompanies(equipment, 
            enterprises, brands);
        foreach (var item in brandWithEquipment)
        {
            Console.WriteLine($"Enterprise: {item.EnterpriseName}  Brand: {item.BrandName}  " +
                $"Type: {item.TypeOfEquipment}");
        }


        Console.WriteLine("\n Equipment Allowed For Employees\n");
        var equipmentAndWorkers = queriesExecutor.GetEquipmentAllowedForEmployee
            (equipment, employees);
        foreach (var item in equipmentAndWorkers)
        {
            Console.WriteLine(item.EnterpriseId);
            Console.WriteLine(item.Equipment);
            foreach (var employee in item.EmployeesAllowedXElements)
            {
                Console.WriteLine(XElementToObject.Employee(employee));
            }
            Console.WriteLine();
        }


        Console.WriteLine("\n The Youngest Employee\n");
        var youngestEmployee = queriesExecutor.GetYoungestEmployee(employees);
        Console.WriteLine(youngestEmployee);


        Console.WriteLine("\n Equipment And Amount Of Employee\n");
        var amountOfWorkersForEachEquipment = queriesExecutor.GetEquipmentAndAmountOfEmployees
            (equipment, connections, brands);
        foreach (var item in amountOfWorkersForEachEquipment)
        {
            Console.WriteLine($"№: {item.EquipmentId}\t - {item.TypeOfEquipment}\t  " +
                $"Brand: {item.BrandName}\t amount of workers: {item.AmountOfEmployees}\t");
        }


        Console.WriteLine("\nNumber Of Equipment Per Employee\n");
        var amountOfEquipments = queriesExecutor.GetNumberOfEquipmentPerEmployees
            (connections, employees);
        foreach (var item in amountOfEquipments)
        {
            Console.WriteLine($"№: {item.EmployeeId}\t {item.EmployeeName} " +
                $"{item.EmployeeSurname} - {item.AmountOfEquipment}\t");
        }


        Console.WriteLine("\nThe History Of Using Of Equipment\n");
        var useOfEquipment = queriesExecutor.GetUseOfEquipment
            (connections, equipment, brands);
        foreach (var item in useOfEquipment)
        {
            Console.WriteLine($"№: {item.ConnectionId}\t equipment №{item.EquipmentId}\t Price: " +
                $"{item.PriceOfEquipment}\t Brand: {item.BrandName}\t");
        }


        Console.WriteLine("\nHigh Income Company And Employees\n");
        var highIncomeCompanyAndEmployees = queriesExecutor.GetHighIncomeCompanyAndEmployees(enterprises, employees);
        foreach (var item in highIncomeCompanyAndEmployees)
        {
            Console.WriteLine($"№: {item.Employee}\t Company: {item.Enterprisename}\t  " +
                $"Income: {item.Income}\t");
        }


        Console.WriteLine("\nSorted Employees Which Were Born In Some Month\n");
        var employeeBornInSomeMonth = queriesExecutor.GetSortedEmployeeBornInSomeMonth(employees, 10);
        foreach (var item in employeeBornInSomeMonth)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nAvarage Income\n");
        var averageIncome = queriesExecutor.GetAverageIncome(enterprises);
        Console.WriteLine(averageIncome);


        Console.WriteLine("\nAmount Of Equipment On Brand\n");
        var brandAndAmountOfEquipment = queriesExecutor.GetAmountOfEquipmentOnBrand
            (brands, equipment);
        foreach (var item in brandAndAmountOfEquipment)
        {
            Console.WriteLine($"Brand: {item.EnterpriseId}  amount of equipments: {item.AmountOfEquipment}");
        }


        Console.WriteLine("\nAll Laptops And Computers\n");
        var allLaptopsAndComputers = queriesExecutor.GetLaptopsAndComputers
            (equipment);
        foreach (var item in allLaptopsAndComputers)
        {
            Console.WriteLine(item);
        }
    }
}