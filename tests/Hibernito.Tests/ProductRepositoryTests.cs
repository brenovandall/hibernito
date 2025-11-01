using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hibernito.Tests
{
    public class ProductRepositoryTests : IClassFixture<RepositoryFixture>
    {
        private readonly RepositoryFixture _fixture;

        public ProductRepositoryTests(RepositoryFixture fixture)
        {
            _fixture = fixture;

            new SchemaExport(_fixture.Cfg).Execute(false, true, false);
        }


    }
}
