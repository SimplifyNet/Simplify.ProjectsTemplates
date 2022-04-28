using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Simplify.FluentNHibernate;

namespace MyProjectWindowsServiceWithDatabase.Database.IntegrationTests.Dangerous;

[TestFixture]
[Category("Integration")]
public class SchemaUpdate
{
	[Test]
	public void UpdateSchema()
	{
		var cfg = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json", false)
			.Build();

		new MyProjectWindowsServiceWithDatabaseSessionFactoryBuilder(cfg)
			.CreateConfiguration()
			.UpdateSchema(x => x.CreateIndexesForForeignKeys());
	}
}