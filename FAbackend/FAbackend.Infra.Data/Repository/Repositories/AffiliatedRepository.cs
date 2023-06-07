﻿using FAbackend.Entities.Models;
using FAbackend.Infra.Data.Context;
using FAbackend.Infra.Data.Repository.Interfaces;

namespace FAbackend.Infra.Data.Repository.Repositories
{
	public class AffiliatedRepository : GenericRepository<Affiliated>, IAffiliatedRepository
	{
		public AffiliatedRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
