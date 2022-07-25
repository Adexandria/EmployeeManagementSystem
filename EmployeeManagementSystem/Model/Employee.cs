namespace EmployeeManagementSystem.Model
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
        public virtual Department Department { get; set; }
        
    }
}
