using System.Xml.Linq;

namespace Laba2_dotnet;
public class EquipmentAllowedForEmployee
{
    public int EnterpriseId { get; set; }
    public Equipment Equipment { get; set; }
    public IEnumerable<Employee> EmployeesAllowed { get; set; }
    public IEnumerable<XElement> EmployeesAllowedXElements { get; set; }
}