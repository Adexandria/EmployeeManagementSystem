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

        //public static ISessionFactory CreateSessionFactory()
        //{
        //    return Fluently.Configure()
        //        .Database(
        //            MsSqlConfiguration.MsSql2008
        //                .ConnectionString(
        //                    @"Data Source=(localdb)\MSSQLLocalDB;Database=employeedb;Integrated Security=True;")
        //                .ShowSql()
        //        )
        //        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
        //        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
        //        .BuildSessionFactory();
        //}

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008
                        .ConnectionString(
                            @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ADMIN\Desktop\Phase II\TutorialWithAdeola\EmployeeManagementSystem-1\EmployeeManagementSystem\EmployeeDB1.mdf;Integrated Security = True; Connect Timeout = 30")
                        .ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

    }
}
