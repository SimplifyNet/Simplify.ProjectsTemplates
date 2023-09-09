using NHibernate;
using Simplify.Repository.FluentNHibernate;

namespace MyProjectSchedulerWithDatabase.Database;

public class MyProjectSchedulerWithDatabaseUnitOfWork : TransactUnitOfWork, IMyProjectSchedulerWithDatabaseUnitOfWork
{
	public MyProjectSchedulerWithDatabaseUnitOfWork(ISessionFactory sessionFactory) : base(sessionFactory)
	{
	}
}