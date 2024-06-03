using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using Microsoft.Extensions.Configuration;
using Simplify.FluentNHibernate;
using Simplify.FluentNHibernate.Conventions;

namespace MyProjectSchedulerWithDatabase.Database;

public class MyProjectSchedulerWithDatabaseSessionFactoryBuilder(IConfiguration configuration)
	: SessionFactoryBuilderBase(configuration, "MyProjectSchedulerWithDatabaseDatabaseConnectionSettings")
{
	public override FluentConfiguration CreateConfiguration() =>
		FluentConfiguration.InitializeFromConfigMsSql(Configuration, ConfigSectionName)
			.AddMappingsFromAssemblyOf<MyProjectSchedulerWithDatabaseSessionFactoryBuilder>(PrimaryKey.Name.Is(x => "ID"),
				Table.Is(x => x.EntityType.Name + "s"),
				ForeignKey.EndsWith("ID"),
				ForeignKeyConstraintNameConvention.WithConstraintNameConvention());
}