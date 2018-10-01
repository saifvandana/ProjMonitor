using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMonitor.Interface;
using ProjectMonitor.Models;

namespace ProjectMonitor.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ProjectMonitorContext _projectMonitorContext;
		public UserRepository(ProjectMonitorContext projectMonitorContext)
		{
			_projectMonitorContext = projectMonitorContext;
		}
		public IEnumerable<User> Users => _projectMonitorContext.User;
	}
}
