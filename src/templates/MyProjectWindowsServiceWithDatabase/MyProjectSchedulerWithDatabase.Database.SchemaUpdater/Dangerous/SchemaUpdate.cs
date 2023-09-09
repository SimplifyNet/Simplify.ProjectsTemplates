using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Simplify.FluentNHibernate;

namespace MyProjectSchedulerWithDatabase.Database.SchemaUpdater.Dangerous;

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

		new MyProjectSchedulerWithDatabaseSessionFactoryBuilder(cfg)
			.CreateConfiguration()
			.UpdateSchema(x => x.CreateIndexesForForeignKeys());
	}
}