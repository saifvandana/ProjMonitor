using System.Collections.Generic;
using ProjectMonitor.Models;

namespace ProjectMonitor.Interface
{
	public interface IUserRepository
	{
		IEnumerable<User> Users { get; }
	}
}