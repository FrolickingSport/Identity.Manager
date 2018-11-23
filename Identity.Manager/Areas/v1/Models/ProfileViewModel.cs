using Identity.Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Manager.Areas.v1.Models
{
	public class ProfileViewModel
	{
		public Guid Id { get; set; }

		public IEnumerable<KeyValueModel> Claims { get; set; }

		public ProfileViewModel()
		{
		}

		public ProfileViewModel(ManagedUser user)
		{
			Id = user.Id;
		}

		public static IEnumerable<ProfileViewModel> GetUserProfiles(IEnumerable<ManagedUser> users)
		{
			var profiles = new List<ProfileViewModel>();
			foreach (ManagedUser user in users)
			{
				profiles.Add(new ProfileViewModel(user));
			}

			return profiles;
		}
	}
}
