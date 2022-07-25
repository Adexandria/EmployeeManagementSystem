using EmployeeManagementSystem.Model;
using FluentNHibernate.Mapping;

namespace EmployeeManagementSystem.Sevices
{
    public class EmployeeMap :ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(e => e.Id);
            Map(x => x.Email);
            Map(x => x.Department).CustomType<Department>();
            Map(x => x.Name);

        }
    }
}