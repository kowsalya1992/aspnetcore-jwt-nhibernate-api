
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace NhApiDemo
{
    public class NHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                            MsSqlConfiguration.MsSql2012
                            .ConnectionString("Server=(localdb)\\MSSQLLocalDB;Database=TestDb;Trusted_Connection=True;TrustServerCertificate=True;")
                            .Driver<NHibernate.Driver.MicrosoftDataSqlClientDriver>()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                .BuildSessionFactory();
        }
    }
}