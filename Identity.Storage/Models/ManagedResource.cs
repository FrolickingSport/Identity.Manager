﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Storage.Models
{
	public abstract class ManagedResource
	{
		public Guid Id { get; set; }

		public bool Enabled { get; set; }

		public string Name { get; set; }

		public string DisplayName { get; set; }

		public string Description { get; set; }

		public ICollection<ManagedUserClaim> UserClaims { get; set; }
	}
}
