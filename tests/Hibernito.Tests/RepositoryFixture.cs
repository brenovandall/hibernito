using Hibernito.Domain;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Hibernito.Tests
{
    public class RepositoryFixture : IDisposable
    {
        public Configuration Cfg { get; private set; } = default!;
        public ISessionFactory SessionFactory { get; private set; } = default!;

        public RepositoryFixture()
        {
            SetupConfigurationSchema();
            SetupSessionFactory();
        }

        private void SetupConfigurationSchema()
        {
            Cfg = new Configuration();
            Cfg.Configure();
            Cfg.AddAssembly(typeof(Product).Assembly);
        }

        private void SetupSessionFactory()
        {
            SessionFactory = Cfg.BuildSessionFactory();
        }

        public void Dispose()
        {
            SessionFactory.Dispose();
        }
    }
}
