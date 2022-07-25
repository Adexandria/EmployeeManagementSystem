using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace EmployeeManagementSystem.Sevices
{
    public class FluentNhibernateHelper
    {
        public FluentNhibernateHelper()
        {

        }

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008
                        .ConnectionString(
                            @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Asus\Documents\Employee.mdf; Integrated Security = True; Connect Timeout = 30")
                        .ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false,true))
                .BuildSessionFactory();
        }
        //Data Source=(localdb)\MSSQLLocalDB;Database=EmployeeDb;Integrated Security=True;
    }
}
