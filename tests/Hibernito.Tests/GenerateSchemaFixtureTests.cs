using Hibernito.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Hibernito.Tests
{
    public class GenerateSchemaFixtureTests
    {
        [Fact]
        public void NHibernate_CanGenerateSchema_WhenLoaded()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Product).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }
    }
}
