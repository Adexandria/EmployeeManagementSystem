using EmployeeManagementSystem.Model;
using NHibernate;
using NHibernate.Linq;

namespace EmployeeManagementSystem.Sevices
{
    public class EmployeeRepository : IEmployee
    {
        private readonly NHibernate.ISession session;
        public EmployeeRepository()
        {
            session = FluentNhibernateHelper.CreateSessionFactory().OpenSession();
        }
        public IEnumerable<Employee> GetAllEmployees
        {
            get
            {
                return session.Query<Employee>();
            }
        }

        public async Task AddEmployee(Employee employee) // Gideon
        {
            ITransaction transaction = session.BeginTransaction();
            await session.SaveAsync(employee);
            await transaction.CommitAsync();
        }

        public async Task DeleteEmployee(Employee employee) // Gideon
        {
            ITransaction transaction = session.BeginTransaction();
            await session.DeleteAsync(employee);
            await transaction.CommitAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await session.Query<Employee>().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateEmployee(Employee employee) //Iruoma
        {
            Employee currentEmployee = await session.Query<Employee>().FirstOrDefaultAsync(s => s.Id == employee.Id);
            if(employee is null)
            {
                throw new NullReferenceException(nameof(employee));
            }
            ITransaction transaction = session.BeginTransaction();
            await session.UpdateAsync(employee);
            await transaction.CommitAsync();

        }

        //Add another functionality
    }
}
