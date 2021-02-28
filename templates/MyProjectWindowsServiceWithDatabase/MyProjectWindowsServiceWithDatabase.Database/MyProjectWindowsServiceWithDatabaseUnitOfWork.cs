using NHibernate;
using Simplify.Repository.FluentNHibernate;

namespace MyProjectWindowsServiceWithDatabase.Database
{
	public class MyProjectWindowsServiceWithDatabaseUnitOfWork : TransactUnitOfWork, IMyProjectWindowsServiceWithDatabaseUnitOfWork
	{
		public MyProjectWindowsServiceWithDatabaseUnitOfWork(ISessionFactory sessionFactory) : base(sessionFactory)
		{
		}
	}
}