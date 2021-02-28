using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using Microsoft.Extensions.Configuration;
using Simplify.FluentNHibernate;
using Simplify.FluentNHibernate.Conventions;
using Simplify.Repository.FluentNHibernate;

namespace MyProjectWindowsServiceWithDatabase.Database
{
	public class MyProjectWindowsServiceWithDatabaseSessionFactoryBuilder : SessionFactoryBuilderBase
	{
		public MyProjectWindowsServiceWithDatabaseSessionFactoryBuilder(IConfiguration configuration) : base(configuration, "MyProjectWindowsServiceWithDatabaseDatabaseConnectionSettings")
		{
		}

		public override FluentConfiguration CreateConfiguration() =>
			FluentConfiguration.InitializeFromConfigMsSql(Configuration, ConfigSectionName)
				.AddMappingsFromAssemblyOf<MyProjectWindowsServiceWithDatabaseSessionFactoryBuilder>(PrimaryKey.Name.Is(x => "ID"),
					Table.Is(x => x.EntityType.Name + "s"),
					ForeignKey.EndsWith("ID"),
					ForeignKeyConstraintNameConvention.WithConstraintNameConvention());
	}
}