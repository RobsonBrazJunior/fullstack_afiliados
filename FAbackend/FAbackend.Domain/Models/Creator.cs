﻿namespace FAbackend.Domain.Models
{
	public class Creator
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Affiliated> Affiliateds { get; set; }
	}
}
