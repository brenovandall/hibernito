using Hibernito.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
