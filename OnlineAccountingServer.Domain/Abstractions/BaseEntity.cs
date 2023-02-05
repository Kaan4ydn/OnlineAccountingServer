﻿namespace OnlineAccountingServer.Domain.Abstractions
{
	public abstract class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set;}
	}
}
