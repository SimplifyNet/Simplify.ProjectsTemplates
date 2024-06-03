﻿using NHibernate;
using Simplify.Repository.FluentNHibernate;

namespace MyProjectSchedulerWithDatabase.Database;

public class MyProjectSchedulerWithDatabaseUnitOfWork(ISessionFactory sessionFactory)
	: TransactUnitOfWork(sessionFactory), IMyProjectSchedulerWithDatabaseUnitOfWork;