using Microsoft.Extensions.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using Simplify.FluentNHibernate;
using Simplify.FluentNHibernate.Conventions;
using Simplify.Repository.FluentNHibernate;

namespace MyProjectSchedulerWithDatabase.Database;

public class MyProjectSchedulerWithDatabaseSessionFactoryBuilder : SessionFactoryBuilderBase
{
	public MyProjectSchedulerWithDatabaseSessionFactoryBuilder(IConfiguration configuration)
		: base(configuration, "MyProjectSchedulerWithDatabaseDatabaseConnectionSettings")
	{
	}

	public override FluentConfiguration CreateConfiguration() =>
		FluentConfiguration.InitializeFromConfigMsSql(Configuration, ConfigSectionName)
			.AddMappingsFromAssemblyOf<MyProjectSchedulerWithDatabaseSessionFactoryBuilder>(PrimaryKey.Name.Is(x => "ID"),
				Table.Is(x => x.EntityType.Name + "s"),
				ForeignKey.EndsWith("ID"),
				ForeignKeyConstraintNameConvention.WithConstraintNameConvention());
}