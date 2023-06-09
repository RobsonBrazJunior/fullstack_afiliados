﻿using FAbackend.Domain.Entities;
using FAbackend.Infra.Data.Context;
using FAbackend.Infra.Data.Repository.Interfaces;

namespace FAbackend.Infra.Data.Repository.Repositories
{
	public class CreatorRepository : GenericRepository<Creator>, ICreatorRepository
	{
		public CreatorRepository(ApplicationContext context) : base(context)
		{
		}
	}
}
