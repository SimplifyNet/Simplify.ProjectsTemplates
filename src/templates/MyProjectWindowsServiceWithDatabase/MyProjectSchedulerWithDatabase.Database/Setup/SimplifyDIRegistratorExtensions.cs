using Microsoft.Extensions.Configuration;
using MyProjectSchedulerWithDatabase.MyEntities;
using Simplify.DI;
using Simplify.Repository.FluentNHibernate;

namespace MyProjectSchedulerWithDatabase.Database.Setup;

public static class SimplifyDIRegistratorExtensions
{
	public static IDIRegistrator RegisterMyProjectSchedulerWithDatabase(this IDIRegistrator registrator) =>
		registrator.Register(
				r => (MyProjectSchedulerWithDatabaseSessionFactoryBuilder)new MyProjectSchedulerWithDatabaseSessionFactoryBuilder(
					r.Resolve<IConfiguration>()).Build(), LifetimeType.Singleton)
			.Register(r => new MyProjectSchedulerWithDatabaseUnitOfWork(r.Resolve<MyProjectSchedulerWithDatabaseSessionFactoryBuilder>()
				.Instance))
			.Register<IMyProjectSchedulerWithDatabaseUnitOfWork>(r => r.Resolve<MyProjectSchedulerWithDatabaseUnitOfWork>())
			.Register(r => r.Resolve<MyProjectSchedulerWithDatabaseUnitOfWork>().Session)

			.RegisterTransactRepository<IMyEntity, IMyProjectSchedulerWithDatabaseUnitOfWork>()
			.Register<IMyEntityServiceService, MyEntityService>();
}