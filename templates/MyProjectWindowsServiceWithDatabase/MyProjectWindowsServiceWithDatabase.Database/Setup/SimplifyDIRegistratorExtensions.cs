using Microsoft.Extensions.Configuration;
using MyProjectWindowsServiceWithDatabase.MyEntities;
using Simplify.DI;
using Simplify.Repository.FluentNHibernate;

namespace MyProjectWindowsServiceWithDatabase.Database.Setup
{
	public static class SimplifyDIRegistratorExtensions
	{
		public static IDIRegistrator RegisterMyProjectWindowsServiceWithDatabase(this IDIRegistrator registrator) =>
			registrator.Register(
					r => (MyProjectWindowsServiceWithDatabaseSessionFactoryBuilder)new MyProjectWindowsServiceWithDatabaseSessionFactoryBuilder(
						r.Resolve<IConfiguration>()).Build(), LifetimeType.Singleton)
				.Register(r => new MyProjectWindowsServiceWithDatabaseUnitOfWork(r.Resolve<MyProjectWindowsServiceWithDatabaseSessionFactoryBuilder>()
					.Instance))
				.Register<IMyProjectWindowsServiceWithDatabaseUnitOfWork>(r => r.Resolve<MyProjectWindowsServiceWithDatabaseUnitOfWork>())
				.Register(r => r.Resolve<MyProjectWindowsServiceWithDatabaseUnitOfWork>().Session)

				.RegisterTransactRepository<IMyEntity, IMyProjectWindowsServiceWithDatabaseUnitOfWork>()
				.Register<IMyEntityServiceService, MyEntityService>();
	}
}